using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public List<int> CustomerAccounts { get; set; } = new List<int>();
        public int TotalAccounts { get; set; } = 0;
        public int TotalDocs { get; set; } = 0;
        public int TotalQuerys { get; set; } = 0;


    }
}
