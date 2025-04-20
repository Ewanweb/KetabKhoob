using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
        [MaxLength(11, ErrorMessage = "شماره تلفن نا معتبر است")]
        [MinLength(11, ErrorMessage = "شماره تلفن نا معتبر است")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
        [MaxLength(11, ErrorMessage = "شماره تلفن نا معتبر است")]
        [MinLength(11, ErrorMessage = "شماره تلفن نا معتبر است")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }   
        
        [Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید ")]
        [Compare(nameof(Password), ErrorMessage = "کلمه های عبور یکسان نیستند")]
        public string ConfirmPassword { get; set; }
    }
}
