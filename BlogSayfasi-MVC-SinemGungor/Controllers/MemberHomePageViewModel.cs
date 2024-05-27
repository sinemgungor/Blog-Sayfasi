using BlogSayfasi_MVC_SinemGungor.Models;

namespace BlogSayfasi_MVC_SinemGungor.Controllers
{
    internal class MemberHomePageViewModel
    {
        public List<Category> FollowedCategories { get; set; }
        public List<Article> Articles { get; set; }
    }
}