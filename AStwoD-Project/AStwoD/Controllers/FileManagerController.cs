using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.Models;
using PagedList;

namespace AStwoD.Controllers
{
    public partial class ControlPanelController : Controller
    {

        #region PICTURES
        public ActionResult Pictures(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<FileModel> pictures = new List<FileModel>();
            string[] filePaths = Directory.GetFiles(Server.MapPath("//Content//images//"));
            foreach (var path in filePaths)
            {
                string name = path.Split('\\').Last();
                pictures.Add(new FileModel(name, path));
            }
            return View(pictures.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult UploadImage(List<HttpPostedFileBase> filesUpload)
        {
            foreach (var fileUpload in filesUpload)
            {
                if (fileUpload != null)
                {
                    string path = Server.MapPath("\\Content\\images\\");
                    string filename = fileUpload.FileName;
                    if (filename != null) fileUpload.SaveAs(Path.Combine(path, filename));
                }
            }
            return RedirectToAction("Pictures");
        }
        public ActionResult DeletePicture(string name)
        {
            string path = Server.MapPath("\\Content\\images\\");
            string filename = Path.GetFileName(name);
            try
            {
                System.IO.File.Delete(Path.Combine(path, filename));
            }
            catch { }
            return RedirectToAction("Pictures");
        }
        #endregion PICTURES

        #region StyleSheet

        public ActionResult StyleSheets(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<FileModel> stylesheets = new List<FileModel>();
            string[] filePaths = Directory.GetFiles(Server.MapPath("//Content//css//"));
            foreach (var path in filePaths)
            {
                string name = path.Split('\\').Last();
                stylesheets.Add(new FileModel(name, path));
            }
            return View(stylesheets.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult UploadCSS(List<HttpPostedFileBase> filesUpload)
        {
            foreach (var fileUpload in filesUpload)
            {
                if (fileUpload != null)
                {
                    string path = Server.MapPath("\\Content\\css\\");
                    string filename = fileUpload.FileName;
                    if (filename != null) fileUpload.SaveAs(Path.Combine(path, filename));
                }
            }
            return RedirectToAction("StyleSheets");
        }
        public ActionResult DeleteStylesheet(string name)
        {
            string path = Server.MapPath("\\Content\\css\\");
            string filename = Path.GetFileName(name);
            try
            {
                System.IO.File.Delete(Path.Combine(path, filename));
            }
            catch { }
            return RedirectToAction("StyleSheets");
        }

        #endregion StyleSheet

        #region JavaScripts
        public ActionResult JScripts(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<FileModel> jscripts = new List<FileModel>();
            string[] filePaths = Directory.GetFiles(Server.MapPath("\\Content\\js\\"));
            foreach (var path in filePaths)
            {
                string name = path.Split('\\').Last();
                jscripts.Add(new FileModel(name, path));
            }
            return View(jscripts.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult UploadJS(List<HttpPostedFileBase> filesUpload)
        {
            foreach (var fileUpload in filesUpload)
            {
                if (fileUpload != null)
                {
                    string path = Server.MapPath("\\Content\\js\\");
                    string filename = fileUpload.FileName;
                    if (filename != null) fileUpload.SaveAs(Path.Combine(path, filename));
                }
            }
            return RedirectToAction("JScripts");
        }
        public ActionResult DeleteJS(string name)
        {
            string path = Server.MapPath("\\Content\\js\\");
            String filename = Path.GetFileName(name);
            try
            {
                System.IO.File.Delete(Path.Combine(path, filename));
            }
            catch { }
            return RedirectToAction("JScripts");
        }
        #endregion JavaScripts
    }
}
