using Empresa.Models;
using Empresa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Empresa.Controllers
{
    public class ActividadController : Controller
    {
        private EmpresaEntities db = new EmpresaEntities();
        public static int idTemp = 0;

        public ActionResult Listar(int? id)
        {
            try
            {
                if (id != null)
                {
                    idTemp = Convert.ToInt32(id);
                }
                IQueryable<Actividad> actividades;
                actividades = db.Actividad.Where(a => a.Id_Empleado == idTemp);
                return View(actividades.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public ActionResult CerrarSesion()
        {
            try
            {
                var e = db.Empleado.Find(idTemp);
                e.Usuario = e.Usuario;
                e.Clave = e.Clave;
                e.Autenticado = 0;
                e.Id = e.Id;
                db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Redirect("~/Empleado/Autenticacion");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public ActionResult Crear()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        [HttpPost]
        public ActionResult Crear(ActividadVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Actividad a = new Actividad();
                    a.Id_Empleado = idTemp;
                    a.Descripcion = model.Descripcion;

                    db.Actividad.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Listar", "Actividad", new { id = idTemp });
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}