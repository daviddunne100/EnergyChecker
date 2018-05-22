using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnergyChecker.DAL;
using EnergyChecker.ViewModels;

namespace EnergyChecker.Controllers
{
    public class HomeController : Controller
    {
        private EnergyCheckerContext db = new EnergyCheckerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<RegistrationDateGroup> data = from user in db.User
                                                   group user by user.RegistrationDate into dateGroup
                                                   select new RegistrationDateGroup()
                                                   {
                                                       RegistrationDate = dateGroup.Key,
                                                       UserCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}