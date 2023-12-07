using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_App.Models
{
    public class Purchase
    {
        [Key]
        public int OrderId { get; set; }
        public String Uemail { get; set; }
        public DateTime Created { get; set; }
        public int Amount { get; set; }
        public int PaymentId { get; set; }
        public int BillingId { get; set; }
    }
}
