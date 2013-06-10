using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.Classes;
using AStwoD.DAL.Entity_First_Model;
using AStwoD.DAL.Repositories;
using AStwoD.Infrastructure.Abstract;
using AStwoD.Models;
using Newtonsoft.Json;
using Ninject;

namespace AStwoD.Controllers
{
    public class ControlPanelController : Controller
    {
       
        private PageRepository repository;
        private MenuRepository menuRepository;

        public ControlPanelController()
        {
            repository = new PageRepository();
            menuRepository = new MenuRepository();
        }
        [Authorize(Roles="Admin,SEO")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult Pages()
        {
            return View(repository.GetAll());
        }

        [Authorize(Roles="SEO")]
        public ActionResult PagesForSEO()
        {
            return View(repository.GetAll());
        }

        [Authorize(Roles = "SEO")]
        public ActionResult UpdateForSEO(int id)
        {
            var model = (PageModel)repository.Get(id);
            return View(model);
        }

        [Authorize(Roles = "SEO")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateForSEO(PageModel model)
        {
            try
            {
                repository.UpdatePage(model.ID, model.LabelForURL, model.LabelForMenu, model.Title, model.MetaDescription, model.MetaKeywords, model.ParentID, model.Content,model.MenuWeight, model.IsMenu);
                return RedirectToAction("PagesForSEO");
            }
            catch
            {
                return View();
            }
        }
        
        [Authorize(Roles="Admin")]
        public ActionResult Details(int id)
        {

            return RedirectToAction("Index", "Home", new { laberlForURL = repository.Get(id).LabelForURL});
        }

        [Authorize(Roles="Admin")]
        public ActionResult Create()
        {
            var model = new PageModel();
            model.parents = new SelectList(repository.GetAll(), "ID", "LabelForURL");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(PageModel model)
        {
            try
            {
                repository.CreatePage(model.LabelForURL, model.LabelForMenu, model.Title,model.MetaDescription, model.MetaKeywords, model.ParentID, model.Content,model.MenuWeight,model.IsMenu);
                return RedirectToAction("Pages");
            }
            catch
            {
                //throw new Exception("Невозможно добавить страницу");
                return View();
            }
        }

        //
        // GET: /ControlPanel/Edit/5
        [Authorize (Roles="Admin")]
        public ActionResult Update(int id)
        {
            var model = (PageModel)repository.Get(id);
            model.parents = new SelectList(repository.GetAll(), "ID", "LabelForURL");
            return View(model);
        }

        //
        // POST: /ControlPanel/Edit/5
        [Authorize(Roles = "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(PageModel model)
        {
            try
            {
                repository.UpdatePage(model.ID, model.LabelForURL, model.LabelForMenu, model.Title, model.MetaDescription, model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight, model.IsMenu);
                return RedirectToAction("Pages");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                repository.Remove(id);
                return RedirectToAction("Pages");
            }
            catch
            {
                throw new Exception("remove elem error");
            }
        }


        public ActionResult GetMenu()
        {
             var model =  menuRepository.GetAll();
            return PartialView(model);
        }
    }
}


/*
            if (Request.IsAjaxRequest())
            {
                List<Page> list = new List<Page>();
                var items = repository.GetAll();
                foreach(var item in items)
                {
                    list.Add((Page)item);
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
*/