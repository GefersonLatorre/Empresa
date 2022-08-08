using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Empresa.Models;
using Empresa.Models.ViewModels;

namespace Empresa.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult Autenticacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticacion(EmpleadoVM model)
        {
            try
            {
                List<ListaEmpleadosVM> lst;
                bool usuarioValido = false;
                bool claveValida = false;
                bool autenticado = true;

                using (EmpresaEntities db = new EmpresaEntities())
                {
                    lst = (from l in db.Empleado
                                select new ListaEmpleadosVM
                                {
                                    Id = l.Id,
                                    Usuario = l.Usuario,
                                    Clave = l.Clave,
                                    Autenticado = l.Autenticado
                                }).ToList();
                }

                foreach (var item in lst)
                {                 
                    if (model.Usuario == item.Usuario)
                    {
                        usuarioValido = true;
                        if (model.Clave == item.Clave)
                        {
                            claveValida = true;
                            if (item.Autenticado == 1)
                            {
                                return Redirect("~/Actividad/Listar/" + item.Id);
                            }
                            else
                            {
                                model.Id = item.Id;
                                autenticado = false;
                            }
                        }
                    }           
                }

                if (!usuarioValido)
                {
                    ModelState.AddModelError("Usuario", "El Usuario no se encuentra registrado");
                }
                else
                {
                    if (!claveValida)
                    {
                        ModelState.AddModelError("Clave", "La Clave es incorrecta");
                    }
                }                

                if (ModelState.IsValid && usuarioValido && claveValida)
                {
                    using (EmpresaEntities db = new EmpresaEntities())
                    {
                        var e = db.Empleado.Find(model.Id);
                        e.Usuario = model.Usuario;
                        e.Clave = model.Clave;
                        e.Autenticado = 1;
                        e.Id = model.Id;

                        db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                if (autenticado && usuarioValido && claveValida)
                {
                    return Redirect("~/Actividad/Listar/" + model.Id);
                }
                else
                {
                    return View();
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}