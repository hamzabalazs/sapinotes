using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapinotesAPI.Data.Models
{
    public class Major
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int majorID { get; set; }
        [Required]
        public string majorName { get; set; }
    }
}
