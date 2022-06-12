using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapinotesAPI.Data.Models
{
    public class Document
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int documentID { get; set; }
        [Required]
        public string documentName { get; set; }
        [Required]
        public string ContentType { get; set; }
        [Required]
        public long? documentSize { get; set; }
    }
}
