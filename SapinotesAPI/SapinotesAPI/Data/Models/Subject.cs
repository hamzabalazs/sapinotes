using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapinotesAPI.Data.Models
{
    public class Subject
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subjectID { get; set; }
        [Required]
        public string subjectName { get; set; }
        [Required]
        public int majorID { get; set; }
    }
}
