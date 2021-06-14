﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Tbl_Hizmet")]
    public class Hizmet
    {
        [Key]
        public int HizmetId { get; set; }
        [DisplayName("Hizmet Başlık")]
        [Required,StringLength(150,ErrorMessage ="En fazla 150 karakter olmalıdır.")]
        public string Baslik { get; set; }
        [DisplayName("Hizmet Açıklama")]
        public string Aciklama { get; set; }
        [DisplayName("Hizmet Resim")]
        public string ResimURL { get; set; }
    }
}