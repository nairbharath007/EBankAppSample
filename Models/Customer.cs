using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace EBankAppSample.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        // 1:M relationship with Account
        public List<Account>? Accounts { get; set; }

        // 1:M relationship with Document
        public List<Document>? Documents { get; set; }

        // 1:M relationship with Query
        public List<Query>? Queries { get; set; }

        
    }
}
