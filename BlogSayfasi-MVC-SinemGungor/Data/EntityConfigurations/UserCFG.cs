using BlogSayfasi_MVC_SinemGungor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSayfasi_MVC_SinemGungor.Data.EntityConfigurations
{
    public class UserCFG :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //User uye = new User()
            //{
            //    Id = 1,
            //    UserName = "sinem",
            //    NormalizedUserName = "SINEM",
            //    Email = "sinem@sinem.com",
            //    NormalizedEmail = "SINEM@SINEM.COM",
            //    EmailConfirmed = false,
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //};
            //PasswordHasher<User> hasher = new PasswordHasher<User>();
            //uye.PasswordHash = hasher.HashPassword(uye, "Sinem_123");

            User uye1 = new User()
            {
                Id = 2,
                UserName = "sinem",
                FirstName="Sinem",
                LastName="Güngör",
                NormalizedUserName = "SINEM",
                Email = "sinem@sinem.com",
                NormalizedEmail = "SINEM@SINEM.COM",
                EmailConfirmed = false,
                ProfilePictureUrl = "/pictures/pp1.jpg" ,
            ConcurrencyStamp = Guid.NewGuid().ToString()
            };
        

            User uye2 = new User()
            {
                Id = 3,
                UserName = "sena",
                FirstName ="Sena",
                LastName="Malkoç",
                NormalizedUserName = "SENA",
                Email = "sena.malkoc@gmail.com",
                NormalizedEmail = "SENA.MALKOC@GMAIL.COM",
                EmailConfirmed = false,
                ProfilePictureUrl = "/pictures/pp2.jpg",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            User uye3 = new User()
            {
                Id = 4,
                UserName = "sema",
                FirstName="Sema",
                LastName="Öztürkler",
                NormalizedUserName = "SEMA",
                Email = "sema@gmail.com",
                NormalizedEmail = "SEMA@GMAIL.COM",
                EmailConfirmed = false,
                ProfilePictureUrl = "/pictures/pp3.jpg",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            uye1.PasswordHash = hasher.HashPassword(uye1, "Sinem_123");
            uye2.PasswordHash = hasher.HashPassword(uye2, "Sinem_123");


            builder.HasData(uye1,uye2,uye3);
        }
    }
}
