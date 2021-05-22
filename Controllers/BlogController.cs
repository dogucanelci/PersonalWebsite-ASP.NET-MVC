using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TatilSitesiproje.Models.Siniflar;
namespace TatilSitesiproje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Models.Siniflar.Context c = new Models.Siniflar.Context();

        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.deger1 = c.Blogs.ToList();
            by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int id )
        {
            by.deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
    }
}