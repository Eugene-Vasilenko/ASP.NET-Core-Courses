using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1.Configuration
{
    public class AuthOptions
    {
        public const string Issuer = "AuthServer";
        public const string Audience = "IdentityClient";
        public const string Key = "this is my custom Secret key for authnetication";
        public const int LifeTime = 50;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
