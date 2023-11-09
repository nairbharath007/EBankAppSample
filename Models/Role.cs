using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // 1:M relationship with User
        public List<User>? Users { get; set; }
    }
}
