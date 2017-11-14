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
                var medicine = new Medicine() {
                    EAN = "010101",
                    Description = "Galvus",
                    Composition = "100 mg"
            
                };

                ctx.Medicines.Add(medicine);
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