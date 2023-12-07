using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_App.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [DisplayName("Name On Card")]
        [RegularExpression("^(?!.*[;:!@#$%^*+?\\\\\\/<>0-9]).*$", ErrorMessage = "Invalid Character: ?!.*[;:!@#$%^*+?\\/<>0123456789")]
        public string CardName {  get; set; }
        [Required]
        [DisplayName("Card Number")]
        [RegularExpression("^[4][0-9]{15}|[5][2-4][0-9]{14}$", ErrorMessage = "Invalid Card Number/Type")]
        public long CardNumber { get; set; }
        [Required]
        [DisplayName("Card Type")]
        public string CardType { get; set; }
        [NotMapped]
        [Required]
        [DisplayName("Expiry Date Month")]
        [RegularExpression("[0][1-9]|[1][0-2]", ErrorMessage = "Please input vaild Month")]
        public string ExpiryDateMonth { get; set; }
        [Required]
        [DisplayName("Expiry Date Year")]
        [RegularExpression("[2][2-9]|[3][0-7]", ErrorMessage = "Please input vaild Year")]
        public string ExpiryDateYear { get; set; }
        [NotMapped]
        [Required]
        [DisplayName("Security Code")]
        [RegularExpression("^[0-9]{3}$", ErrorMessage = "Please input vaild Security Code")]
        public int CVV { get; set; }
    }
}
