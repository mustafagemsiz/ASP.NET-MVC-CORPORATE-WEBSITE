using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        Db_KurumsalContext db = new Db_KurumsalContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            return View(db.Hakkimizda.ToList());
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
            var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(hakkimizda);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda hakkimizda)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();
                h.Aciklama = hakkimizda.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            
            return View(hakkimizda);
        }
    }
}