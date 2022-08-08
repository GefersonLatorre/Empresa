using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empresa.Models.ViewModels
{
    public class EmpleadoVM
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }
        public int Autenticado { get; set; }
        public int Id { get; set; }
    }
}