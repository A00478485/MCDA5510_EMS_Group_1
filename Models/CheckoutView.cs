using System.ComponentModel.DataAnnotations;

namespace EMS_App.Models
{
    public class CheckoutView
    {
        public virtual Purchase purchase {  get; set; }
        public virtual List<Ticket> Ticket { get; set; }
    }
}
