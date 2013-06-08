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

        [HttpPost]
        public ActionResult SearchPages(String search)
        {
            if (Request.IsAjaxRequest())
            {
                var list = new List<Page>();
                list.Add(new Page("Opa", "opopo", 1, "oooooo"));
                list.Add(new Page("Opa", "Страница Оро", 2, "oooooo"));
                list.Add(new Page("Opa3", "opopo3", 3, "oooooo"));

                return Json(list.Where(x => x.Name == search), JsonRequestBehavior.AllowGet);
            }
            else { return null; }
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
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
        public ActionResult Edit(int id, FormCollection collection)
        {
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