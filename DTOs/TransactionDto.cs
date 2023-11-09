using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.DTOs
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public string TransactionType { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
