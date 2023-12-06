using System.ComponentModel.DataAnnotations;

namespace EMS_App.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardName {  get; set; }
        [CreditCard]
        public int CardNumber { get; set; }
        public string CardType { get; set; }
        public int CardExpiration { get; set; }
    }
}
