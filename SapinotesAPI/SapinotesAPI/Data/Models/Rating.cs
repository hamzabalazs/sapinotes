using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapinotesAPI.Data.Models
{
    public class Rating
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ratingID { get; set; }
        [Required]
        public int noteID { get; set; }
        [Required]
        public int userID { get; set; }
        [Required]
        public int ratingValue { get; set; }
    }
}
