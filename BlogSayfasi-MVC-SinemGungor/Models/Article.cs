namespace BlogSayfasi_MVC_SinemGungor.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        public int ReadCount { get; internal set; }
    }
}
