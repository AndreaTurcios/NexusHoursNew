using System.Web;
using System.Web.Mvc;
using SistemaMVC_Demo.Models.Entidad;
using SistemaMVC_Demo.Models;

namespace SistemaMVC_Demo.Controllers
{
    public class Cliente : Controller
    {
        // GET: NexusWorkHoursS
        
        public ActionResult Create()
        {
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



        [HttpPost]
        public ActionResult Edit(int id, proyectos proyecto)
        {
            try
            {
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