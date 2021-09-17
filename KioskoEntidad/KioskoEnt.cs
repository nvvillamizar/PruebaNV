using System.ComponentModel.DataAnnotations;

namespace KioskoEntidad
{
    public class KioskoEnt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]        
        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int IdUsuario { get; set; }
    }
}
