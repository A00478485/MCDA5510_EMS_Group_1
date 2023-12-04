using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_App.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int Availability {  get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
