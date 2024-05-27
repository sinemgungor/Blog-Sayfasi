using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BlogSayfasi_MVC_SinemGungor.Data.Context;
using BlogSayfasi_MVC_SinemGungor.Models;
using BlogSayfasi_MVC_SinemGungor.Models.VM;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlogSayfasi_MVC_SinemGungor.Areas.UyePaneli.Controllers
{
    [Area("UyePaneli")]
    [Authorize]
    public class TopicsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BlogContext _context;

        public TopicsController(UserManager<User> userManager, BlogContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Follow(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var userCategory = new UserCategory
            {
                UserId = user.Id,
                CategoryId = id
            };

            _context.UserCategories.Add(userCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SelectCategories()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var categories = _context.Categories.ToList();
            var followedCategoryIds = _context.UserCategories
                .Where(uc => uc.UserId == user.Id)
                .Select(uc => uc.CategoryId)
                .ToList();

            var model = new CategorySelectionVM
            {
                Categories = categories,
                SelectedCategoryIds = followedCategoryIds
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCategories(CategorySelectionVM model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var existingFollowedCategories = _context.UserCategories
                .Where(uc => uc.UserId == user.Id)
                .ToList();

            _context.UserCategories.RemoveRange(existingFollowedCategories);
            await _context.SaveChangesAsync();

            foreach (var categoryId in model.SelectedCategoryIds)
            {
                _context.UserCategories.Add(new UserCategory { UserId = user.Id, CategoryId = categoryId });
            }

            await _context.SaveChangesAsync();
            TempData["CategorySelectMessage"] = "Kategori takipe alındı.";
            return RedirectToAction("SelectCategories");
        
           

        }

        [HttpPost]
        public async Task<IActionResult> Unfollow(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var userCategory = _context.UserCategories.SingleOrDefault(uc => uc.UserId == user.Id && uc.CategoryId == id);
            if (userCategory != null)
            {
                _context.UserCategories.Remove(userCategory);
                await _context.SaveChangesAsync();
            }
            TempData["CategoryUnfollowMessage"] = "Kategori takipten çıkarıldı.";
            return RedirectToAction("SelectCategories");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCategory(string newCategoryName)
        {
            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                return RedirectToAction("Anasayfa");
            }

            var category = new Category { Name = newCategoryName };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            TempData["CategoryAddMessage"] = "Kategori başarıyla eklendi.";
            return RedirectToAction("SelectCategories", "Topics");
        }

    }
}
