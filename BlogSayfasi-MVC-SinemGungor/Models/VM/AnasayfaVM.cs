namespace BlogSayfasi_MVC_SinemGungor.Models.VM
{
    public class AnasayfaVM
    {
        public List<Article> FollowedTopicArticles { get; set; } = new List<Article>();
        public List<Article> PopularArticles { get; set; } = new List<Article>();
        public List<Article> AllArticles { get; set; } = new List<Article>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Category> FollowedCategories { get; set; } = new List<Category>();
        public List<Article> GeneralArticles { get; set; } = new List<Article>();
    }
}
