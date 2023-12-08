using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_App.Models
{
    public class Event
    {
        public Guid eventID { get; set; }

        [Required]
        public string eventHeader { get; set; }

        [Required]
        public string eventDescription { get; set; }

        [Required]
        public DateTime eventStartTime { get; set; }

        [Required]
        public DateTime eventEndTime { get; set; }
 
    }
}
