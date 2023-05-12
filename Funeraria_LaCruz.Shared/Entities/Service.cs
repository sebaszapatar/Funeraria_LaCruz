﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class Service
    {

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Inventario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public float Stock { get; set; }


        public ICollection<FunerariaCategory>? FunerariaCategories { get; set; }

        [Display(Name = "Categorías")]
        public int MedicineCategoriesNumber => FunerariaCategories == null ? 0 : FunerariaCategories.Count;

        public ICollection<FunerariaImage>? MedicineImages { get; set; }

        [Display(Name = "Imágenes")]
        public int MedicineImagesNumber => FunerariaCategories == null ? 0 : FunerariaCategories.Count;

        [Display(Name = "Imagén")]
        public string MainImage => MedicineImages == null ? string.Empty : MedicineImages.FirstOrDefault()!.Image;


    }
}
