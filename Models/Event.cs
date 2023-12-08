using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EMS_App.Models
{
    public class Event
    {
        [DisplayName("Event ID")]
        public Guid eventID { get; set; }

        [Required]
        [DisplayName("Event Header")]
        public string eventHeader { get; set; }

        [Required]
        [DisplayName("Event Short Description")]
        public string eventShortDescription { get; set; }

        [Required]
        [DisplayName("Event Description")]
        public string eventDescription { get; set; }

        [Required]
        [DisplayName("Event Start Time")]
        public DateTime eventStartTime { get; set; }

        [Required]
        [DisplayName("Event End Time")]
        public DateTime eventEndTime { get; set; }
 
    }
}
