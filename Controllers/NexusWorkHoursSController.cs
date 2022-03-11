using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC_Demo.Models.Entidad;
using SistemaMVC_Demo.Models;

namespace SistemaMVC_Demo.Controllers
{
    public class NexusWorkHoursSController : Controller
    {
        // GET: NexusWorkHoursS
        public ActionResult Index()
        {
            List<EntidadProyecto> listProyectos;
            using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1()) { 
                listProyectos = (from d in db.proyectos
                                   select new EntidadProyecto
                                   {
                                       ID_proyecto = d.ID_proyecto,
                                       proyecto_nombre = d.proyecto_nombre 
                                   }).ToList();
            }
                return View(listProyectos);
        }


        public ActionResult Login()
        {
            List<EntidadLogin> listLogin;
            using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1())
            {
                listLogin = (from d in db.login
                                 select new EntidadLogin
                                 {
                                     ID_user = d.ID_user,
                                     user = d.user
                                 }).ToList();
            }
            return View(listLogin);
        }


        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(proyectos proyecto)
        {
            try
            {
                using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1())
                {
                    db.proyectos.Add(proyecto);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1())
            {
                return View(db.proyectos.Where(x => x.ID_proyecto == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1())
                {
                    proyectos proyecto = db.proyectos.Where(x => x.ID_proyecto == id).FirstOrDefault();
                    db.proyectos.Remove(proyecto);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id) {

            using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1())
            {
                return View(db.proyectos.Where(x => x.ID_proyecto == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, proyectos proyecto)
        {
            try {
                using (NexusWorkHoursSEntities1 db = new NexusWorkHoursSEntities1())
                {
                    db.Entry(proyecto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            
        }
    }
}