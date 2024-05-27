using BlogSayfasi_MVC_SinemGungor.Models.VM;
using BlogSayfasi_MVC_SinemGungor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Text.Encodings.Web;

namespace BlogSayfasi_MVC_SinemGungor.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IEmailSender _emailSender;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender= emailSender;

        }
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                string[] emailParts = register.Email.Split('@');
                string username = emailParts[0];
                string[] nameParts = username.Split('.');
                string firstName = nameParts[0];
                string lastName = nameParts.Length > 1 ? nameParts[1] : ""; 
                string userUrl = "/profile/" + username;

                User uye = new User();

                uye.UserName = username;
                uye.Email = register.Email;
                uye.FirstName = firstName;
                uye.LastName = lastName;
                uye.Url = userUrl;




                uye.PasswordHash = _userManager.PasswordHasher.HashPassword(uye, register.Password);

                var result = await _userManager.CreateAsync(uye);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(uye, "Uye");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(uye);
                    var callbackUrl = Url.Action(nameof(ConfirmEmail), "Register", new { userId = uye.Id, code }, protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(uye.Email, "Emailinizi doğrulayın",
                        $"Lütfen emailinizi doğrulamak için <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayın</a>.");

                    return RedirectToAction("EmailDogrulamaBekleme", "Register");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Register", "Register");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Kullanıcı ID '{userId}' bulunamadı.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        public IActionResult EmailDogrulamaBekleme()
        {
            return View();
        }
    }
}
