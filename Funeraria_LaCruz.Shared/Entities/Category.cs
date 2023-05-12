﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class Category
    {

        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public ICollection<FunerariaCategory>? FunerariaCategories { get; set; }

        [Display(Name = "Productos")]
        public int MedicineCategoriesNumber => FunerariaCategories == null ? 0 : FunerariaCategories.Count;


    }
}
