using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string State { get; set; } // Pending or Completed
        public bool IsActive { get; set; }
    }
}
