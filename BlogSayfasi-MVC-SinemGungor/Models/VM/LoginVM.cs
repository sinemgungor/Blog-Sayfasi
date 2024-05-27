using System.ComponentModel.DataAnnotations;

namespace BlogSayfasi_MVC_SinemGungor.Models.VM
{
    public class LoginVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola alanı gereklidir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
