﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.Models;
using Newtonsoft.Json;

namespace AStwoD.Controllers
{
    public class ControlPanelController : Controller
    {
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
            throw new Exception("Создана страница: "+page.Title);
            return View();
        }

        //
        // GET: /ControlPanel/Pages

        public ActionResult Pages()
        {
            if (Request.IsAjaxRequest())
            {
                var list = new List<Page>();
                list.Add(new Page("Opa", "opopo", 1, "oooooo"));
                list.Add(new Page("Opa2", "opopo2", 2, "oooooo"));
                list.Add(new Page("Opa3", "opopo3", 3, "oooooo"));

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
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

        //
        // GET: /ControlPanel/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ControlPanel/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
