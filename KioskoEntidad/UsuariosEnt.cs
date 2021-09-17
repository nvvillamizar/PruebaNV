using System.ComponentModel.DataAnnotations;

namespace KioskoEntidad
{
    public class UsuariosEnt
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }
    }
}
