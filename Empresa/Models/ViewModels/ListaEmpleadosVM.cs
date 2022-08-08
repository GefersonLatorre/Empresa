using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empresa.Models.ViewModels
{
    public class ListaEmpleadosVM
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int Autenticado { get; set; }
        public int Id { get; set; }
    }
}