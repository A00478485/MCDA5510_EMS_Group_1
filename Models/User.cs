using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace EMS_App.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name cannot contain numbers")]
        [DisplayName("Name")]

        public string Uname { get; set; }
        [Required(ErrorMessage = "Date of Birth Is Required")]
        [DisplayName("Date of Birth")]

        public DateTime Udob { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email Address")]
        [Key]
        public string Uemail { get; set; }
        [Required(ErrorMessage = "Canadian or USA Mobile Number is required")]
        [RegularExpression(@"^(\+?1\s?[-.\s]?)?(\(\d{3}\)|\d{3})[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Invalid Mobile Number")]
        [DisplayName("Mobile Number")]

        public int Unumber { get; set; }




    }
}
