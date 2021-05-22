using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TatilSitesiproje.Models.Siniflar;
namespace TatilSitesiproje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Models.Siniflar.Context c = new Models.Siniflar.Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();

            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var deger2 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(deger2);
        }        
        public PartialViewResult Partial2()
        {
            var deger3 = c.Blogs.Where(x => x.ID==1).Take(1).ToList();
            return PartialView(deger3);
        }
        public PartialViewResult Partial3()
        {
            var deger4 = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(deger4);
        }        
        public PartialViewResult Partial4()
        {
            var deger5 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deger5);
        }        
        public PartialViewResult Partial5()
        {
            var deger6 = c.Blogs.Take(3).ToList();
            return PartialView(deger6);
        }
        
    }
}