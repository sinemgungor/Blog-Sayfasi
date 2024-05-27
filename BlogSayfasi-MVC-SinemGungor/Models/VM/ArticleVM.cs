using System.ComponentModel.DataAnnotations;

namespace BlogSayfasi_MVC_SinemGungor.Models.VM
{
    public class ArticleVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public List<int> SelectedCategories { get; set; }
    }
}
