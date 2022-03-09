using SistemaMVC_Demo.Models;
using SistemaMVC_Demo.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMVC_Demo.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            List<EntidadPrueba> listaPrueba;
            using (pruebaEntities db = new pruebaEntities())
            {
                listaPrueba = (from d in db.prueba
                               select new EntidadPrueba
                               {
                                   id = d.id,
                                   nombre = d.nombre
                               }).ToList();
            }
                return View(listaPrueba);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(prueba prueba) {
            try
            {
                using (pruebaEntities db = new pruebaEntities()) {
                    db.prueba.Add(prueba);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Service
        public ActionResult Delete(long id) {
            using (pruebaEntities db = new pruebaEntities()) 
            {
                return View(db.prueba.Where(x => x.id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection) {
            try
            {
                using (pruebaEntities db = new pruebaEntities())
                {
                    prueba prueba = db.prueba.Where(x => x.id == id).FirstOrDefault();
                    db.prueba.Remove(prueba);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            { 
                return View();
            }
        }
    }
}