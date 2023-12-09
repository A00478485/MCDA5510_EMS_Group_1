using System.ComponentModel.DataAnnotations;

namespace EMS_App.Models
{
    public class Event
    {
    
        [Required]
        [Key]
        public string Ename { get; set; }
        [Required]
        public string Ediscription { get; set; }
        [Required]
        public string EBanner { get; set; }
    }
}
