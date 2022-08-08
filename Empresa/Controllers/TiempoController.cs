using Empresa.Models;
using Empresa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Empresa.Controllers
{
    public class TiempoController : Controller
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
                IQueryable<Tiempo> tiempos;
                tiempos = db.Tiempo.Where(a => a.Id_Actividad == idTemp);
                return View(tiempos.ToList());
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
        public ActionResult Crear(TiempoVM model)
        {
            try
            {
                List<ListaTiempoVM> lst;

                using (EmpresaEntities db = new EmpresaEntities())
                {
                    lst = (from t in db.Tiempo
                           select new ListaTiempoVM
                           {
                               Id = t.Id,
                               Id_Actividad = t.Id_Actividad,
                               Fecha = t.Fecha,
                               Horas = t.Horas
                           }).Where(a => a.Id_Actividad == idTemp).ToList();
                }

                var h = model.Horas;
                foreach (var item in lst)
                {
                    h = h + item.Horas;
                    if (h >= 9)
                    {                        
                        ModelState.AddModelError("Horas", "Los tiempos de una actividad solo pueden sumar máximo 8 horas.");
                    }
                }

                if (ModelState.IsValid)
                {
                    Tiempo t = new Tiempo();
                    t.Id_Actividad = idTemp;
                    t.Fecha = model.Fecha;
                    t.Horas = model.Horas;
                    db.Tiempo.Add(t);
                    db.SaveChanges();
                    return RedirectToAction("Listar", "Tiempo", new { id = idTemp });
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Eliminar(int? id)
        {
            try
            {
                var t = db.Tiempo.Find(id);
                db.Tiempo.Remove(t);
                db.SaveChanges();
                return RedirectToAction("Listar", "Tiempo", new { id = idTemp });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}