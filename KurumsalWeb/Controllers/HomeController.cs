using KurumsalWeb.Models.DataContext;
using System;
using KurumsalWeb.Models.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        private Db_KurumsalContext db = new Db_KurumsalContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Bilgi = db.Bilgi.SingleOrDefault();
            return View();
        }

       public ActionResult SliderPartial()
        {
            Index();
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));
        }

        public ActionResult HizmetPartial()
        {
            Index();
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId).Take(4));
        }

        public ActionResult Hakkimizda()
        {
            Index();
            return View(db.Hakkimizda.SingleOrDefault());
        }

        public ActionResult Hizmetler()
        {
            Index();
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }

        public ActionResult Iletisim()
        {
            Index();
            return View(db.İletisim.SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            Index();

            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "epostaadresiniz";
                WebMail.Password = "epostaparolanız";
                WebMail.SmtpPort = 587;
                WebMail.Send("epostaadresiniz", konu, email + "<br/>" + mesaj);
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";

            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            }
            return View();
        }

        public ActionResult Blog(int Sayfa=1)
        {
            Index();
            return View(db.Blog.Include("Kategori").Include("Yorums").ToList().OrderByDescending(x=>x.BlogId));
        }

        public ActionResult BlogDetay(int id)
        {
            Index();
            var b = db.Blog.Include("Kategori").Include("Yorums").Where(x=>x.BlogId==id).SingleOrDefault();
            return View(b);
        }

        public ActionResult BlogKategori(int id, int Sayfa=1)
        {
            Index();
            var b = db.Blog.Include("Kategori").Where(x=>x.Kategori.KategoriId==id).ToList();
            return View(b);
        }

        public JsonResult YorumYap(string adsoyad,string eposta,string icerik,int blogid)
        {
            Index();
            if (icerik==null)
            {
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            db.Yorum.Add(new Yorum { AdSoyad = adsoyad, Eposta = eposta, Incerik = icerik, BlogId = blogid,Onay=false });
            db.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BlogKategoriPartial()
        {
            Index();
            return PartialView(db.Kategori.Include("Blogs").ToList().OrderByDescending(x=>x.KategoriAd));
        }

        public ActionResult BlogKayitPartial()
        {
            Index();
            return PartialView(db.Blog.ToList().OrderByDescending(x=>x.BlogId));
        }

        public ActionResult FooterPartial()
        {
            Index();
            ViewBag.İletisim = db.İletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Hizmet = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);
           return PartialView();
        }

    }
}