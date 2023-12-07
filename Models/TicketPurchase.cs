using System.ComponentModel.DataAnnotations;

namespace EMS_App.Models
{
    public class TicketPurchase
    {
        [Key]
        public int OrderId { get; set; }
        [Key] 
        public int TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
