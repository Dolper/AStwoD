using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public ActionResult Index(string labelForURL)
        {
            labelForURL = labelForURL ?? "index";
            //если  root/ не вписан в адрес и это не картинка, то вписать, иначе получить из БД страницу

            return View((PageModel)(repository.GetPageByName(labelForURL)));
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
