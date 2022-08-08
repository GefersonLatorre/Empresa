using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empresa.Models.ViewModels
{
    public class ListaTiempoVM
    {
        public DateTime Fecha { get; set; }
        public int Horas { get; set; }
        public int Id_Actividad { get; set; }
        public int Id { get; set; }
    }
}