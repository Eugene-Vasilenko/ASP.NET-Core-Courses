using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;

        public AccountController(UserManager<UserInfo> userManager, SignInManager<UserInfo> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var user = new UserInfo
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                Company = registerModel.Company,
                Age = registerModel.Age,
                Sex = registerModel.Sex
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }

            foreach (var identityError in result.Errors)
            {
                ModelState.AddModelError("Register", identityError.Description);
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            ModelState.AddModelError("Login", "Wrong username or password");

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ChangePasswordByAdmin(ChangePasswordByAdmin changePasswordByAdmin,
            [FromServices] IPasswordValidator<UserInfo> passwordValidator, [FromServices] IPasswordHasher<UserInfo> passwordHasher)
        {
            var user = await _userManager.FindByIdAsync(changePasswordByAdmin.Id);

            if (user != null)
            {
                var result = await passwordValidator.ValidateAsync(_userManager, user, changePasswordByAdmin.Password);

                if (result.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, changePasswordByAdmin.Password);
                    await _userManager.UpdateAsync(user);

                    return Ok();
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError("Password", identityError.Description);
                }
            }
            else
            {
                return NotFound();
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ChangePasswordByUser(ChangePasswordByUser changePasswordByUser)
        {
            var user = await _userManager.FindByIdAsync(changePasswordByUser.Id);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, changePasswordByUser.OldPassword, changePasswordByUser.NewPassword);

                if (result.Succeeded)
                {
                    return Ok();
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError("Password", identityError.Description);
                }
            }
            else
            {
                return NotFound();
            }

            return BadRequest(ModelState);
        }
    }
}
