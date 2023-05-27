using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace DemoProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string? Password { get; set; }
    }
}
