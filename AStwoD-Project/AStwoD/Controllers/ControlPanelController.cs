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
        [Authorize]
        public ActionResult Page()
        {
            return View();
        }


        //
        // POST: /ControlPanel/AddPage
        [Authorize]
        [HttpPost]
        public ActionResult Page(Page page)
        {
            throw new Exception("Создана страница: " + page.Title);
            return View();
        }


        //
        // GET: /ControlPanel/Pages
        [Authorize]
        public ActionResult Pages()
        {
            var items = repository.GetAll();
            return View(items);
        }



        //
        // GET: /ControlPanel/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ControlPanel/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ControlPanel/Create
        [Authorize]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Page model)
        {
            try
            {
                repository.CreatePage(model.Name, model.Link, model.Title, "", "", model.ParentID, model.Content);
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
                repository.UpdatePage(model.ID, model.Name, model.Link, model.Title, model.MetaD, model.MetaK, model.ParentID, model.Content);
                return RedirectToAction("Pages");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult SendEmail(string emailTo,string subject,string body)
        {
            try
            {
               EMailManager.SendEMail(emailTo, subject,body);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
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