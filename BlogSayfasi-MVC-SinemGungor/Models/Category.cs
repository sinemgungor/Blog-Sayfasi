namespace BlogSayfasi_MVC_SinemGungor.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        public ICollection<UserCategory> UserCategories { get; set; }
    }
}
