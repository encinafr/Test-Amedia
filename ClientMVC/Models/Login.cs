using System.ComponentModel.DataAnnotations;

namespace ClientMVC.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email / Username")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
