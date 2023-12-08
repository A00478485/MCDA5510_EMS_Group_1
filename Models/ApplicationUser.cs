using Microsoft.AspNetCore.Identity;

namespace EMS_App.Models
{
    public class ApplicationUser: IdentityUser
    {
        public String Name {  get; set; }
        public String Number { get; set; }

    }
}
