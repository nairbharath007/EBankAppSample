using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; } 
        public string AccountType { get; set; }   
        public DateTime OpeningDate { get; set; } 
        public bool IsActive { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }
    }
}
