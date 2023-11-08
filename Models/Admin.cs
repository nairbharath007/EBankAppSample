using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        // Relationships
        /*[ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }*/

        /*[ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }*/

        /*public List<Account> Accounts { get; set; }*/
        /*public List<Document> Documents { get; set; }
        public List<Query> Queries { get; set; }
        public List<Customer> Customers { get; set; }*/

        /*[ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }*/

    }
}
