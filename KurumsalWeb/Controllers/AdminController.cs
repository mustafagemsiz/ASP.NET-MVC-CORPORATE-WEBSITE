using KurumsalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;

namespace KurumsalWeb.Controllers
{
    public class AdminController : Controller
    {
        Db_KurumsalContext db = new Db_KurumsalContext();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta && x.Sifre == admin.Sifre).SingleOrDefault();
            if (login != null)
            {
                if (login.Eposta == admin.Eposta && login.Sifre == admin.Sifre)
                {
                    Session["adminId"] = login.AdminId;
                    Session["adminEposta"] = login.Eposta;
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.Uyari = "Kullanıcı adı ya da Şifre yanlış";
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["adminId"] = null;
            Session["adminEposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}