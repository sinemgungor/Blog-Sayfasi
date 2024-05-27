using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BlogSayfasi_MVC_SinemGungor.Data.Context;
using BlogSayfasi_MVC_SinemGungor.Models;
using System.Linq;
using System.Threading.Tasks;
using BlogSayfasi_MVC_SinemGungor.Models.VM;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;


namespace BlogSayfasi_MVC_SinemGungor.Areas.UyePaneli.Controllers
{
    [Area("UyePaneli")]
    public class ArticleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BlogContext _context;

        public ArticleController(UserManager<User> userManager, BlogContext context)
        {
            _userManager = userManager;
            _context = context;
        }


  
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Challenge();
                }

                var article = new Article
                {
                    Title = model.Title,
                    Content = model.Content,
                    CreatedTime = DateTime.Now,
                    AuthorId = user.Id,
                };

                _context.Articles.Add(article);
                await _context.SaveChangesAsync();

                foreach (var categoryId in model.SelectedCategories)
                {
                    var articleCategory = new ArticleCategory
                    {
                        ArticleId = article.Id,
                        CategoryId = categoryId
                    };
                    _context.ArticleCategories.Add(articleCategory);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("List");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var articles = _context.Articles
                .Where(a => a.AuthorId == user.Id)
                .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
                .ToList();

            return View(articles);
        }

        [AllowAnonymous] 
        public async Task<IActionResult> Read(int id)
        {
            var article = await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }
            article.ReadCount++;
            _context.Update(article);
            await _context.SaveChangesAsync();
            return View(article);
        } 

        [HttpGet]
        public IActionResult AuthorDetails(string username)
        {
            var author = _context.Users
                .Include(u => u.Articles)
                .SingleOrDefault(u => u.UserName == username);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
    }
}
