using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.Models;

namespace AStwoD.Controllers
{
    public partial class ControlPanelController : Controller
    {
      public ActionResult Pictures()
      {
          List<PictureModel> pictures = new List<PictureModel>();
          pictures.Add(new PictureModel("123.jpq","//123.jpg"));
          return View(pictures);
      }
    }
}
