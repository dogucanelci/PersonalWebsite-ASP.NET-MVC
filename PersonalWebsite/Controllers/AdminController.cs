using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TatilSitesiproje.Models.Siniflar;
namespace TatilSitesiproje.Controllers
{
    
    public class AdminController : Controller
    {
        TatilSitesiproje.Models.Siniflar.Context c = new TatilSitesiproje.Models.Siniflar.Context();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }        
        public ActionResult BlogSil(int id)
        {
            var degersil = c.Blogs.Find(id);
            c.Blogs.Remove(degersil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir", b);
        }        
        public ActionResult BlogGuncelle(Blog blg)
        {
            var yeni_b = c.Blogs.Find(blg.ID);

            yeni_b.Aciklama = blg.Aciklama;
            yeni_b.Baslik = blg.Baslik;
            yeni_b.BlogImage = blg.BlogImage;
            yeni_b.Tarih = blg.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //Zaten blogdetay a id degeri tasiniyor,bunu kullaniyoruz.
        [HttpGet]
        public PartialViewResult YorumYazma(int id)
        {
            ViewBag.degerid = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYazma(Yorumlar y)
        {

            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
        [Authorize]
        public ActionResult YorumTablo()
        {
            var deger_yorum = c.Yorumlars.ToList();
            return View(deger_yorum);
        }
        
        public ActionResult Yorumizin(int id)
        {
            var izindeger = c.Yorumlars.Find(id);
            izindeger.izin = true;
            c.SaveChanges();
            return RedirectToAction("YorumTablo");
        }

    }
}