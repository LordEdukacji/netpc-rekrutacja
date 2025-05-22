using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactsApp.Backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContactsApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context)
        {
            _context = context;
        }

        // verifies if cookie contains valid authentication claims
        // located in this controller for simplicity
        // should be moved elsewhere if more account functionality was to be developed
        // GET: api/Contact/cookie
        [HttpGet("cookie")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Contact>>> CheckCookie()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Ok(User.Identity.Name);
            }
            else
            {
                return Unauthorized();
            }
        }

        // returns 
        // GET: api/Contact
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetContacts()
        {
            var dtoList = new List<ContactDTO>();

            foreach (Contact c in _context.Contacts.ToList())
            {
                dtoList.Add(new ContactDTO(c));
            }

            return dtoList;
        }

        // GET: api/Contact/category/{id}
        [HttpGet("category/{id}")]
        public async Task<ActionResult<Categorization>> GetCategorization(long id)
        {
            var categorization = await _context.Categorizations.FindAsync(id);

            if (categorization == null)
            {
                return NotFound();
            }

            return categorization;
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contact/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, ContactWithCategorization contactWithCategories)
        {
            if (id != contactWithCategories.Id)
            {
                return BadRequest();
            }

            // transform the text based categories into a reference
            contactWithCategories.Categories.Id = await FindCategorization(contactWithCategories.Categories.Category, contactWithCategories.Categories.Subcategory);
            Contact contact = new Contact(contactWithCategories);
            contact.Id = id; // could also be copied inside Contact(contactWithCategories)

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contact
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(ContactWithCategorization contactWithCategories)
        {
            // transform the text based categories into a reference
            contactWithCategories.Categories.Id = await FindCategorization(contactWithCategories.Categories.Category, contactWithCategories.Categories.Subcategory);
            Contact contact = new Contact(contactWithCategories);

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ContactExists(long id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }

        private async Task<long> FindCategorization(string category, string? subcategory)
        {
            var foundCategorization = await _context.Categorizations.FirstOrDefaultAsync(c => c.Category == category && c.Subcategory == subcategory);

            if (foundCategorization == null)
            {
                foundCategorization = new Categorization() { Category = category, Subcategory = subcategory };
                _context.Categorizations.Add(foundCategorization);
                await _context.SaveChangesAsync();
            }

            return foundCategorization.Id;
        }
    }
}
