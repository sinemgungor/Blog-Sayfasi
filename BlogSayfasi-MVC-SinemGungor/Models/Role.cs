using Microsoft.AspNetCore.Identity;

namespace identity.Models
{
    public class Role:IdentityRole<int>
    {
        public DateTime OlusturmaZamani { get; set; }
    }
}
