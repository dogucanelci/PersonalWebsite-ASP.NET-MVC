using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSitesiproje.Models.Siniflar;
namespace TatilSitesiproje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Hakkimizdas.ToList();
            return View(deger);
        }
    }
}