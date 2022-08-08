using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empresa.Models.ViewModels
{
    public class ActividadVM
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        public int Id_Empleado { get; set; }
        public int Id { get; set; }
    }
}