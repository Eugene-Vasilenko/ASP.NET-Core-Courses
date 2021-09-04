using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Requirements
{
    public class CustomRequirement : IAuthorizationRequirement
    {
        protected internal string Grade { get; set; }

        public CustomRequirement(string grade)
        {
            Grade = grade;
        }
    }
}
