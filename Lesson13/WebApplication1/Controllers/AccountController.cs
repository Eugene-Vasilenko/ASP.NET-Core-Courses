using ConsoleApp1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly LessonsDbContext _dbContext;

        public AccountController(LessonsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CookieLogin(LoginModel loginModel)
        {
            var student = await _dbContext.Students
                .Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.Username == loginModel.Username && i.Password == loginModel.Password);

            if (student == null)
            {
                return BadRequest();
            }

            var claims = GetClaims(student);

            var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookies", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> TokenLogin(LoginModel loginModel)
        {
            var student = await _dbContext.Students
                .Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.Username == loginModel.Username && i.Password == loginModel.Password);

            if (student == null)
            {
                return BadRequest();
            }

            var claims = GetClaims(student);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: DateTime.UtcNow,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return new ObjectResult(new { access_token = token });
        }


        private List<Claim> GetClaims(Student student)
        {
            var roleClaims = student.Roles.Select(i =>
                new Claim(ClaimTypes.Role, i.RoleName));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, student.Username),
                new Claim("Company", "Existek"),
                new Claim("Sex", "Male"),
            };

            claims.AddRange(roleClaims);

            return claims;
        }



    }
}
