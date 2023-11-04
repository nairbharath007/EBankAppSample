using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.Models
{
    public class Query
    {
        [Key]
        public int QueryId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string QueryText { get; set; }
        public DateTime QueryDate { get; set; }
        public string ReplyText { get; set; }
        public DateTime ReplyDate { get; set; }
        public string Status { get; set; } // Open or Closed
        public bool IsActive { get; set; }
    }
}
