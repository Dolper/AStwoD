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
        private MenuRepository menuRepository;

        public HomeController()
        {

            repository = new PageRepository();
            menuRepository = new MenuRepository();
        }

        public ActionResult Index(string labelForURL)
        {
            labelForURL = labelForURL ?? "index";
            if (labelForURL != "index")
            {
                if (repository.GetPageByName(labelForURL)==null)
                {
                    return View((PageModel)repository.GetPageByName("404"));
                }
            }
            return View((PageModel)(repository.GetPageByName(labelForURL)));
        }

        public ActionResult GetMenu()
        {
            var model = menuRepository.GetAll();
            return PartialView(model);
        }
    }
}
