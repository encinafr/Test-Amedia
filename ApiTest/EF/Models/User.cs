using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Models
{
    [Table("tUsers", Schema = "dbo")]
    public class User
    {
        [Key]   
        public int Cod_usuario { get; set; }
        public string Txt_user { get; set; }
        public string Txt_password { get; set; }
        public string Txt_nombre { get; set; }
        public string Txt_apellido { get; set; }
        public string Nro_doc { get; set; }
        public int Cod_rol { get; set; }
        public int sn_activo { get; set; }

    }
}
