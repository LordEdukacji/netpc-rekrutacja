using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Frontend.Models
{
    public class AccountData
    {
        [EmailAddress]
        public required string email { get; set; }

        [MinLength(8)]
        public required string password { get; set; }

        [SetsRequiredMembers]
        public AccountData(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        [SetsRequiredMembers]
        public AccountData()
        {
            this.email = "";
            this.password = "";
        }
    }
}
