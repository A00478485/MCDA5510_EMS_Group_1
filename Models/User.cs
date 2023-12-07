using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace EMS_App.Models
{
    public class User
    {
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

        [DisplayName("Mobile Number")] 
        public int Unumber { get; set; }

        [DisplayName("Password")]
        [StringLength(10, ErrorMessage = "Password should contain at least 10 characters")]
        public string Password { get; set; }

        public string RePassword { get; set; }





    }
}
