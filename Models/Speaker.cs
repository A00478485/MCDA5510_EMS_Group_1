using System.ComponentModel.DataAnnotations;

namespace EMS_App.Models
{
    public class Speaker
    {
        [Key]
        public int Sid { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        public string SBio { get; set; }
        [Required]
        public string Simage { get; set; }

    }
}
