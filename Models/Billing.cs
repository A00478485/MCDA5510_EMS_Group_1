using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }
        [Required]
        [RegularExpression("^(?!.*[;:!@#$%^*+?\\\\\\/<>0-9]).*$", ErrorMessage = "Invalid Character: ;:!@#$%^*+?\\/<>0123456789")]
        [DisplayName("First Name")]
        public required String BFirstName { get; set; }
        [Required]
        [RegularExpression("^(?!.*[;:!@#$%^*+?\\\\\\/<>0-9]).*$", ErrorMessage = "Invalid Character: ;:!@#$%^*+?\\/<>0123456789")]
        [DisplayName("Last Name")]
        public required String BLastName { get; set; }
        [Required]
        [DisplayName("Address")]
        public required String BAddress1 { get; set; }
        public String? BAddress2 { get; set; }
        [Required]
        [DisplayName("City")]
        [RegularExpression("^(?!.*[;:!@#$%^*+?\\\\\\/<>0-9]).*$", ErrorMessage = "Invalid Character: ;:!@#$%^*+?\\/<>0123456789")]
        public required String BCity { get; set; }
        [Required]
        [DisplayName("Province")]
        [RegularExpression("^(?!.*[;:!@#$%^*+?\\\\\\/<>0-9]).*$", ErrorMessage = "Invalid Character: ;:!@#$%^*+?\\/<>0123456789")]
        public required String BProvince { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        [Remote("ValidatePostalCode", "Tickets", AdditionalFields = "BCountry", ErrorMessage = "Invalid Postal Code")]

        public required String BPostalCode { get; set; }

        [Required]
        [DisplayName("Country")]
        public required String BCountry { get; set; }
    }
}
