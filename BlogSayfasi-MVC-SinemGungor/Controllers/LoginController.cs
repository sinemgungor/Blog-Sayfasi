using BlogSayfasi_MVC_SinemGungor.Models;
using BlogSayfasi_MVC_SinemGungor.Models.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Text.Encodings.Web;

namespace BlogSayfasi_MVC_SinemGungor.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager, IEmailSender emailSender, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Email adresiniz henüz doğrulanmamış.");
                        return View();
                    }

                    var code = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "Login");
                    var callbackUrl = Url.Action(nameof(LoginWithCode), "Login", new { userId = user.Id, code }, protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Giriş yapmanız için link",
                        $"Lütfen giriş yapmak için <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayın</a>.");

               
                    return RedirectToAction("LoginNotification");
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoginWithCode(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Login", "Register");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Kullanıcı ID '{userId}' bulunamadı.");
            }

            var result = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "Login", code);
            if (result)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
  

            return View("Error");
        }

        public IActionResult LoginNotification()
        {
            return View();
        }

        private void SendEmail(string email, string subject, string message)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(emailSettings["SenderName"], emailSettings["SenderEmail"]));
            mimeMessage.To.Add(MailboxAddress.Parse(email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html") { Text = message };

            using (var client = new SmtpClient())
            {
                client.Connect(emailSettings["SmtpServer"], int.Parse(emailSettings["SmtpPort"]), false);
                client.Authenticate(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }
        } 
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");

        }
     
    }
}
