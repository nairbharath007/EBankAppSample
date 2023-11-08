using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string DocumentData { get; set; }
        public string DocumentType { get; set; }
        public DateTime UploadDate { get; set; }
        public string Status { get; set; } // Approved or Pending

        //public string StorageLocation { get; set; }

    }
}
