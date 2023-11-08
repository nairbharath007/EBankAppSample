using System.ComponentModel.DataAnnotations;

namespace EBankAppSample.DTOs
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }
        /*[Required]
        public string DocumentName { get; set; }*/
        [Required]
        public string DocumentType { get; set; }
        public string DocumentData { get; set; }
        /*public bool IsActive { get; set; }*/
        public DateTime UploadDate { get; set; }

        public string Status { get; set; }
        public int CustomerId { get; set; }

    }
}
