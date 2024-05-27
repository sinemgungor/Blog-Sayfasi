using BlogSayfasi_MVC_SinemGungor.Models;

namespace BlogSayfasi_MVC_SinemGungor.Controllers
{
    internal class VisitorHomePageViewModel
    {
        public List<Article> PopularArticles { get; set; }
        public List<Category> Categories { get; set; }
    }
}