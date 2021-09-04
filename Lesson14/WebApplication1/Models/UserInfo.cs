using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class UserInfo : IdentityUser
    {
        public string Company { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}
