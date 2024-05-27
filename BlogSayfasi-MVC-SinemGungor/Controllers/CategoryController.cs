using BlogSayfasi_MVC_SinemGungor.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSayfasi_MVC_SinemGungor.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BlogContext _context;

        public CategoryController(BlogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CategoryArticles(int id)
        {
            var category = await _context.Categories.Include(c => c.ArticleCategories)
                .ThenInclude(ac => ac.Article)
                .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
