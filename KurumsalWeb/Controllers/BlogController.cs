using KurumsalWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class BlogController : Controller
    {
        private Db_KurumsalContext db = new Db_KurumsalContext();
        // GET: Blog
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Blog.Include("Kategori").ToList().OrderByDescending(x=>x.BlogId));
        }
    }
}