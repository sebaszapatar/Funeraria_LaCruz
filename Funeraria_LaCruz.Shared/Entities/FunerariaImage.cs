using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class FunerariaImage
    {
        public int Id { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }


        [Display(Name = "Productos")]
        public int ProductsNumber => Products == null ? 0 : Products.Count;





    }
}
