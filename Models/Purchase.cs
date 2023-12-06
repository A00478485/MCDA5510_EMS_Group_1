using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_App.Models
{
    public class Purchase
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Created { get; set; }
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Required] 
        
        public String BFirstName { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name cannot contain numbers")]
        [DisplayName("Name")] 
        public String BLastName { get; set; }
        [Required]
        public String BAddress1 { get; set; }
        public String BAddress2 { get; set; }
        public String BCity { get; set; }
        [Required]
        public String BProvince { get; set; }
        [Required]
        public String BPostalCode { get; set; }
    }
}
