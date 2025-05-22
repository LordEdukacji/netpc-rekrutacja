using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Backend.Models
{
    // used for storing contacts and categories
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Categorization> Categorizations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // requirement: email is unique
            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // enforce uniqueness
            modelBuilder.Entity<Categorization>()
                .HasIndex(c => new { c.Category, c.Subcategory })
                .IsUnique();
        }
    }
}
