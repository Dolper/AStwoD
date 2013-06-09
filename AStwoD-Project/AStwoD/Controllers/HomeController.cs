using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AStwoD.Classes;
using AStwoD.DAL.Entity_First_Model;
using AStwoD.DAL.Repositories;
using AStwoD.Models;

namespace AStwoD.Controllers
{
    public class HomeController : Controller
    {

        private PageRepository repository;

        public HomeController()
        {

            repository = new PageRepository();
        }

        public ActionResult Index(string name)
        {
            name = name ?? "index";
            return View((Page)(repository.GetPageByName(name)));
        }

        public ActionResult RequestRepair()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RequestRepair(RequestRepairModel model)
        {
            try
            {
                EMailManager eMailManager = new EMailManager();
                eMailManager.SendRequestRepair(model.City, model.FIO, model.Phone, model.Message);
                return RedirectToAction("Index", new { name = "successRequestRepair" });
            }
            catch
            {
                return View();
            }
        }

    }
}
