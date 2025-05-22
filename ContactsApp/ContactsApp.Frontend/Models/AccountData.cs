using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Frontend.Models
{
    // used as model in creation and edition forms
    public class AccountData
    {
        [EmailAddress]
        public required string email { get; set; }

        [MinLength(8)]
        public required string password { get; set; }

        // for sending the request
        [SetsRequiredMembers]
        public AccountData(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        // empty initialization for form
        [SetsRequiredMembers]
        public AccountData()
        {
            this.email = "";
            this.password = "";
        }
    }
}
