using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.DAL.Entity_First_Model;
using AStwoD.DAL.Repositories;
using AStwoD.Models;
using Newtonsoft.Json;

namespace AStwoD.Controllers
{
    public class ControlPanelController : Controller
    {
        private PageRepository repository;

        public ControlPanelController()
        {
            repository = new PageRepository();
        }


        //
        // GET: /ControlPanel/

        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /ControlPanel/AddPage

        public ActionResult Page()
        {
            return View();
        }


        //
        // POST: /ControlPanel/AddPage

        [HttpPost]
        public ActionResult Page(Page page)
        {
            throw new Exception("Создана страница: " + page.Title);
            return View();
        }


        //
        // GET: /ControlPanel/Pages

        public ActionResult Pages()
        {
            var items = repository.GetAll();
            return View(items);
        }



        //
        // GET: /ControlPanel/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ControlPanel/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /ControlPanel/Create

        [HttpPost]
        public ActionResult Create(Page model)
        {
            try
            {
                repository.CreatePage(model.Name, model.Link, model.Title,"","", model.ParentID, model.Content);
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ControlPanel/Edit/5

        [HttpPost]
        public ActionResult Update(int id, FormCollection collection)
        {
/*            Page Model = new Page(name: repository.Name, link: repository.Link, parentID: repository.ParentID, title: repository.Title);*/

            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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