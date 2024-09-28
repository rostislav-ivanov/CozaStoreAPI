using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // POST: api/account/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModelDTO model)
        {
            try
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration for user {Email}", model.Email);
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

        // POST: api/account/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModelDTO model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var userData = "{\"name\": \"" + user.UserName + "\", \"email\": \"" + user.Email + "\"}";

                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTime.Now.AddDays(7)
                    };

                    Response.Cookies.Append("UserData", userData, cookieOptions);

                    return Ok(new { message = "Login successful" });
                }

                return Unauthorized(new { message = "Invalid login attempt" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during login for user {Email}", model.Email);
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

        // POST: api/account/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                Response.Cookies.Delete("UserData");
                return Ok(new { message = "Logout successful" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during logout");
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }
    }
}
