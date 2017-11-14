using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEC_EP1.DAL;
using TEC_EP1.Models;

namespace TEC_EP1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new EasyPharmaDbContext())
            {
                var lab = new Laboratory() {
                    Name = "Novartis",
            
                };

                ctx.Laboratories.Add(lab);
                ctx.SaveChanges();

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}