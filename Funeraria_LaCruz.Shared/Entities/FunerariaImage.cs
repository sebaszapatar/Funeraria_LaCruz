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

        public Service Medicine { get; set; } = null!;

        public int MedicineId { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; } = null!;




    }
}
