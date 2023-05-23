using Funeraria_LaCruz.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class FunerariaCategory
    {
        public int Id { get; set; }

        [Display(Name = "Sub-Categoria")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }

        public int CategoryId { get; set; }
        public Category? Categories { get; set; }

        [Display(Name = "Productos")]
        public int ProductsNumber => Products == null ? 0 : Products.Count;

    }
}
