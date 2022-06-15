using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapinotesAPI.Data.Models
{
    public class Note
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int noteID { get; set; }
        [Required]
        public int userID { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public int subjectID { get; set; }
        [Required]
        public string noteName { get; set; }
        [Required]
        public int noteDocID { get; set; }
        [Required]
        public double noteRatingValue { get; set; }
        [Required]
        public int numberOfRatings { get; set; }
    }
}
