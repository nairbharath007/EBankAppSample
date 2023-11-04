using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // 1:1 relationship with User
        public User User { get; set; }
    }
}
