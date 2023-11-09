using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBankAppSample.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        // 1:1 relationship with Role
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }


        public Customer Customer { get; set; }

        // 1:1 relationship with Customer
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //userscontroller-->admin
        //getallusers()
        //getbyid()
        //update()
        //delete()


    }
}
