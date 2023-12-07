using System.ComponentModel.DataAnnotations;

namespace EMS_App.Models
{
    public class CheckoutView
    {
        public virtual Purchase Purchase {  get; set; }
        public virtual List<Ticket> Ticket { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Billing Billing { get; set; }
    }
}
