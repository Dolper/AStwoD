using System;
using System.Collections.Generic;
using System.IO;
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
         string[] filePaths =  Directory.GetFiles(Server.MapPath("//Content//images//"));
          foreach (var path in filePaths)
          {
              string name = path.Split('\\').Last();
              pictures.Add(new PictureModel(name, path));
          }
          return View(pictures);
      }
        public ActionResult UploadImage(HttpPostedFileBase fileUpload)
        {
            if(fileUpload!=null)
            {
                string path = Server.MapPath("\\Content\\images\\");
                string filename = Path.GetFileName(fileUpload.FileName);
                if(filename!=null) fileUpload.SaveAs(Path.Combine(path,filename));
            }
            return RedirectToAction("Pictures");
        }

    }
}
