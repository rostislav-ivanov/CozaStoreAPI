using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST: api/account/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create a new user with the provided email and password
            var user = new AppUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Automatically log the user in after registration
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Optionally: Set custom cookie after login
                var userData = "{\"name\": \"" + user.UserName + "\", \"email\": \"" + user.Email + "\"}";
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set true for HTTPS
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.Now.AddDays(7)
                };
                Response.Cookies.Append("UserData", userData, cookieOptions);

                return Ok(new { message = "Registration and automatic login successful" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }


        // POST: api/account/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Optionally: Set custom cookies after successful login
                var user = await _userManager.FindByEmailAsync(model.Email);
                var userData = "{\"name\": \"" + user.UserName + "\", \"email\": \"" + user.Email + "\"}";

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set true for HTTPS
                    SameSite = SameSiteMode.None, // Allows cross-origin requests
                    Expires = DateTime.Now.AddDays(7)
                };

                Response.Cookies.Append("UserData", userData, cookieOptions);

                return Ok(new { message = "Login successful" });
            }

            return Unauthorized(new { message = "Invalid login attempt" });
        }

        // POST: api/account/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            Response.Cookies.Delete("UserData");

            return Ok(new { message = "Logout successful" });
        }
    }
}
