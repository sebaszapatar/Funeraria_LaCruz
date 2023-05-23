using System.ComponentModel.DataAnnotations;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class Employee
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

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Dir { get; set; } = null!;

        [Display(Name = "Cargo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Cargo { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Tel { get; set; } = null!;

        [Display(Name = "Correo electrónico")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; } = null!;


    }
}
