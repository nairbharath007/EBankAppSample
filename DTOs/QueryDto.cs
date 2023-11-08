using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.DTOs
{
    public class QueryDto
    {
        public int QueryId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string QueryText { get; set; }

        [Required]
        public DateTime QueryDate { get; set; }

        public string ReplyText { get; set; }
        public DateTime ReplyDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
