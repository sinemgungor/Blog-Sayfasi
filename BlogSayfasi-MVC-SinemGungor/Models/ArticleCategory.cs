using System.ComponentModel.DataAnnotations;

namespace BlogSayfasi_MVC_SinemGungor.Models
{
    public class ArticleCategory
    {
        [Key]
        public int ArticleId { get; set; }
       
        [Key]
        public int CategoryId { get; set; }

        public Article Article { get; set; }
        public Category Category { get; set; }
    }
}
