using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AStwoD.Infrastructure.Abstract;
using AStwoD.Infrastructure.Concrete;
using AStwoD.Models;
using Ninject.Activation;

namespace AStwoD.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        FormsAuthProvider authProv;

        public AccountController()
        {
            authProv = new FormsAuthProvider();
            authProvider = authProv;
        }


        public ActionResult LogOn()
        {
            return View();
        }



        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, String returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return RedirectToAction("Index", "ControlPanel");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректное имя пользователя или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }

           // return View();
        }

        public ActionResult LogOf()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
