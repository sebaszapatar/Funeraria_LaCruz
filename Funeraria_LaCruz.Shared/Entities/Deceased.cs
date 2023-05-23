using System.ComponentModel.DataAnnotations;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class Deceased
    {
        public int Id { get; set; }

        [Display(Name = "Cédula")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Cedula { get; set; } = null!;

        [Display(Name = "Nombre Completo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Sexo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sexo { get; set; } = null!;

        [Display(Name = "Fecha de nacimiento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nacimiento { get; set; } = null!;

        [Display(Name = "Fecha de difunción")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Defuncion { get; set; } = null!;

        [Display(Name = "Causa de muerte")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string CausaMuerte { get; set; } = null!;

        [Display(Name = "Lugar de fallecimiento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LugarFallecimiento { get; set; } = null!;

        [Display(Name = "Estado cívil")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string EstadoCivil { get; set; } = null!;



    }
}