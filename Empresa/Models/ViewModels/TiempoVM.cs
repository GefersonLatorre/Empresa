using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empresa.Models.ViewModels
{
    public class TiempoVM
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Required]
        public int Horas { get; set; }
        public int Id_Actividad { get; set; }
        public int Id { get; set; }
    }
}