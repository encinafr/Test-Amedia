using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClientMVC.Common.Validations
{
    public class UserValidator
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Txt_nombre { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [Display(Name = "Password")]
        public string Txt_password { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int Cod_rol { get; set; }
    }

    [ModelMetadataType(typeof(UserValidator))]
    public partial class UserModel
    {
    }
}
