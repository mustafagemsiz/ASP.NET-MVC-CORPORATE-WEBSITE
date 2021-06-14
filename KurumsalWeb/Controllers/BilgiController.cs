using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class BilgiController : Controller
    {
        Db_KurumsalContext db = new Db_KurumsalContext();
        // GET: Bilgi
        public ActionResult Index()
        {

            return View(db.Bilgi.ToList());
        }


        // GET: Bilgi/Edit/5
        public ActionResult Edit(int id)
        {


            var bilgi = db.Bilgi.Where(x => x.BilgiId == id).SingleOrDefault();
            return View(bilgi);
            

        }

        // POST: Bilgi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Bilgi bilgi, HttpPostedFileBase LogoURL)
        {

            if (ModelState.IsValid)
            {
                var b = db.Bilgi.Where(x => x.BilgiId == id).SingleOrDefault();
                if (LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imgInfo = new FileInfo(LogoURL.FileName);
                    string logoName = LogoURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save(@"~/Uploads/Bilgi/"+logoName);

                    b.LogoURL =@"/Uploads/Bilgi/" + logoName;
                }
                b.Title = bilgi.Title;
                b.Keywords = bilgi.Keywords;
                b.Description = bilgi.Description;
                b.Unvan = bilgi.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilgi);
        }

    }
}
