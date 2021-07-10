﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;

namespace KurumsalWeb.Controllers
{
    public class İletisimController : Controller
    {
        private Db_KurumsalContext db = new Db_KurumsalContext();

        // GET: İletisim
        public ActionResult Index()
        {
            return View(db.İletisim.ToList());
        }

        // GET: İletisim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İletisim İletisim = db.İletisim.Find(id);
            if (İletisim == null)
            {
                return HttpNotFound();
            }
            return View(İletisim);
        }

        // GET: İletisim/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "İletisimId,Adres,Telefon,Fax,Whatsapp,Facebook,Twitter,Instagram")] İletisim İletisim)
        {
            if (ModelState.IsValid)
            {
                db.İletisim.Add(İletisim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(İletisim);
        }

        // GET: İletisim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İletisim İletisim = db.İletisim.Find(id);
            if (İletisim == null)
            {
                return HttpNotFound();
            }
            return View(İletisim);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "İletisimId,Adres,Telefon,Fax,Whatsapp,Facebook,Twitter,Instagram")] İletisim İletisim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(İletisim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(İletisim);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İletisim İletisim = db.İletisim.Find(id);
            if (İletisim == null)
            {
                return HttpNotFound();
            }
            return View(İletisim);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            İletisim İletisim = db.İletisim.Find(id);
            db.İletisim.Remove(İletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
