using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BlogSayfasi_MVC_SinemGungor.Data.Context;
using BlogSayfasi_MVC_SinemGungor.Models;
using BlogSayfasi_MVC_SinemGungor.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlogSayfasi_MVC_SinemGungor.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BlogContext _context;

        public HomeController(UserManager<User> userManager, BlogContext context)
        {
            _userManager = userManager;
            _context = context;
        }
  

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Anasayfa()
        {
       
            var user = await _userManager.GetUserAsync(User);
            var followedCategories = user != null ?
                _context.UserCategories.Where(uc => uc.UserId == user.Id).Select(uc => uc.Category).ToList() : new List<Category>();

            var followedTopicArticles = user != null ?
                _context.Articles.Where(a => a.ArticleCategories.Any(ac => followedCategories.Contains(ac.Category)))
                .Include(a => a.Author)
                .Include(a => a.ArticleCategories).ThenInclude(ac => ac.Category).ToList() : new List<Article>();

            var popularArticles = _context.Articles
                .Include(a => a.Author)
                .Include(a => a.ArticleCategories).ThenInclude(ac => ac.Category)
                .OrderByDescending(a => a.ReadCount).Take(10).ToList();

            var allArticles = _context.Articles
                .Include(a => a.Author)
                .Include(a => a.ArticleCategories).ThenInclude(ac => ac.Category).ToList();

            var categories = _context.Categories.ToList();

            var model = new AnasayfaVM
            {
                FollowedTopicArticles = followedTopicArticles,
                PopularArticles = popularArticles,
                AllArticles = allArticles,
                Categories = categories,
                FollowedCategories = followedCategories
            };

            return View(model);
        }

        
        public async Task<IActionResult> Index()
        {

        
            var articles = _context.Articles
           .Include(a => a.ArticleCategories)
           .ThenInclude(ac => ac.Category)
           .ToList();

            var popularArticles = articles
                .OrderByDescending(a => a.ReadCount)
                .Take(4)
                .ToList();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Challenge();
                }

                var followedCategories = _context.UserCategories
                    .Where(uc => uc.UserId == user.Id)
                    .Select(uc => uc.Category)
                    .ToList();

                var model = new MemberHomePageVM
                {
                    FollowedCategories = followedCategories,
                    Articles = popularArticles
                };

                return View("MemberIndex", model);
            }
            else
            {
                var allCategories = _context.Categories.ToList();

                var model = new VisitorHomePageVM
                {
                    PopularArticles = popularArticles,
                    Categories = allCategories
                };

                return View("VisitorIndex", model);
            }
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

            return RedirectToAction("Anasayfa");
        }

    }
}
