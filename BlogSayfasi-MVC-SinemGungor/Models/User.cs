using Microsoft.AspNetCore.Identity;

namespace BlogSayfasi_MVC_SinemGungor.Models
{
    public class User:IdentityUser<int>
    {
      
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? About { get; set; }
        public string? Url { get; set; }
        public ICollection<UserCategory>? UserCategories { get; set; }
        public ICollection<Article>? Articles { get; set; }

    }
}
