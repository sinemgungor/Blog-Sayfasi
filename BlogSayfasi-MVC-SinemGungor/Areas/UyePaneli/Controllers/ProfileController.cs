


using BlogSayfasi_MVC_SinemGungor.Data.Context;
using BlogSayfasi_MVC_SinemGungor.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BlogSayfasi_MVC_SinemGungor.Areas.UyePaneli.Controllers
{
    [Area("UyePaneli")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly BlogContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager, BlogContext context, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Profile(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            if (currentUser == null)
            {
                return NotFound();
            }

            return View(currentUser);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(User user, IFormFile ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return NotFound();
                }

                var usernameExists = await _userManager.FindByNameAsync(user.UserName);
                if (usernameExists != null && usernameExists.Id != currentUser.Id)
                {
                    ModelState.AddModelError("UserName", "Bu kullanıcı adı zaten mevcut.");
                    return View(user);
                }

                var emailExists = await _userManager.FindByEmailAsync(user.Email);
                if (emailExists != null && emailExists.Id != currentUser.Id)
                {
                    ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanılıyor.");
                    return View(user);
                }

                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.About = user.About;
                currentUser.Url = user.Url;
                currentUser.UserName = user.UserName;
                currentUser.Email = user.Email;

                if (ProfilePicture != null && ProfilePicture.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "pictures");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProfilePicture.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfilePicture.CopyToAsync(stream);
                    }

                    currentUser.ProfilePictureUrl = "/pictures/" + uniqueFileName;
                }

                var result = await _userManager.UpdateAsync(currentUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", new { username = currentUser.UserName });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult ConfirmDelete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync(); 
                return RedirectToAction("Index", "Home", new { area = "" });
            }

          
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("EditProfile", user);
        }


    }
}



