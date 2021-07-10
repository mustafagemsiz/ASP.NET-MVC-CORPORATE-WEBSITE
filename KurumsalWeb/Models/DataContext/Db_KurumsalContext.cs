using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.DataContext
{
    public class Db_KurumsalContext:DbContext
    {
        public Db_KurumsalContext():base("Db_Kurumsal")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Bilgi> Bilgi { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<İletisim> İletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Yorum> Yorum { get; set; }

    }
}