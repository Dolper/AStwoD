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
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Pages()
        {
            return View(repository.GetAll());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "Home", new { LabelForURL = repository.Get(id).LabelForURL });
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new Page();
            model.parents = new SelectList(repository.GetAll(), "ID", "LabelForURL");
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Page model)
        {
            try
            {
                repository.CreatePage(model.LabelForURL, model.LabelForMenu, model.Title,model.MetaD, model.MetaK, model.ParentID, model.Content,model.MenuWeight,model.IsMenu);
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
        [Authorize]
        public ActionResult Update(int id)
        {
            var model = (Page)repository.Get(id);
            model.parents = new SelectList(repository.GetAll(), "ID", "LabelForURL");
            return View(model);
        }

        //
        // POST: /ControlPanel/Edit/5
        [Authorize]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(Page model)
        {
            try
            {
                repository.UpdatePage(model.ID, model.LabelForURL, model.LabelForMenu, model.Title, model.MetaD, model.MetaK, model.ParentID, model.Content, model.MenuWeight, model.IsMenu);
                return RedirectToAction("Pages");
            }
            catch
            {
                return View();
            }
        }
       
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