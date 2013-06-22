using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AStwoD.Classes;
using AStwoD.DAL.Entity_First_Model;
using AStwoD.DAL.Repositories;
using AStwoD.Infrastructure.Abstract;
using AStwoD.Models;
using Newtonsoft.Json;
using Ninject;
using PagedList;

namespace AStwoD.Controllers
{
    public class ControlPanelController : Controller
    {
        private PageRepository repository;
        private MenuRepository menuRepository;
        private ComponentRepository componentRepository;
        private TemplateRepository templateRepository;

        public ControlPanelController()
        {
            repository = new PageRepository();
            menuRepository = new MenuRepository();
            componentRepository = new ComponentRepository();
            templateRepository = new TemplateRepository();
        }

        [Authorize(Roles = "Admin,SEO")]
        public ActionResult Index(string title)
        {
            if (Request.IsAjaxRequest() && title != "")
            {
                List<PageModel> list = new List<PageModel>();
                var items = repository.GetPagesByInputTitle(title);
                foreach (var item in items)
                {
                    if (item.Title != "Root" && item.IsRemove != true)
                    {
                        list.Add((PageModel)item);
                    }
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        #region PAGE

        [Authorize(Roles = "Admin")]
        public ActionResult Pages(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View(repository.GetAll().ToPagedList(pageIndex, pageSize));
        }

        [Authorize(Roles = "SEO")]
        public ActionResult PagesForSEO(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View(repository.GetAll().ToPagedList(pageIndex, pageSize));
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
                repository.UpdatePage(model.ID, model.LabelForURL, model.LabelForMenu, model.Title, model.MetaDescription, model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight, model.IsMenu, model.IsRemove, model.DateCreation);
                return RedirectToAction("PagesForSEO");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "Home", new { laberlForURL = repository.Get(id).LabelForURL });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new PageModel();
            var allPages = repository.GetAll();
            List<astwod_Page> selectListItems = new List<astwod_Page>();
            foreach (var page in allPages)
            {
                if (page.IsRemove != true)
                {
                    selectListItems.Add(page);
                }
            }
            model.parents = new SelectList(selectListItems, "ID", "LabelForURL");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(PageModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = model.ParentID != null ? repository.Get(model.ParentID.Value).LabelForURL : "";
                    if (model.ParentID > 0)
                    {
                        url += "/" + model.LabelForURL.Split('/').Last();
                        repository.CreatePage(url, model.LabelForMenu, model.Title, model.MetaDescription,
                                              model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight,
                                              model.IsMenu, DateTime.Now);
                    }
                    else
                    {
                        repository.CreatePage(model.LabelForURL, model.LabelForMenu, model.Title, model.MetaDescription,
                                              model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight,
                                              model.IsMenu, model.DateCreation);
                    }
                    return RedirectToAction("Pages");
                }
                return View(model);
            }
            catch
            {
                //throw new Exception("Невозможно добавить страницу");
                return View();
            }
        }

        //
        // GET: /ControlPanel/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id)
        {
            var model = (PageModel)repository.Get(id);
            model.LabelForURL = model.LabelForURL.Split('/').Last();
            var allPages = repository.GetAll();
            List<astwod_Page> selectListItems = new List<astwod_Page>();
            foreach (var page in allPages)
            {
                if (page.IsRemove != true)
                {
                    selectListItems.Add(page);
                }
            }
            model.parents = new SelectList(selectListItems, "ID", "LabelForURL");
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
                if (ModelState.IsValid)
                {
                    string url = model.ParentID != null ? repository.Get(model.ParentID.Value).LabelForURL : "";
                    if (model.ParentID > 0)
                    {
                        url += "/" + model.LabelForURL.Split('/').Last();
                        repository.UpdatePage(model.ID, url, model.LabelForMenu, model.Title, model.MetaDescription,
                                              model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight,
                                              model.IsMenu, model.IsRemove, model.DateCreation);
                    }
                    else
                    {
                        repository.UpdatePage(model.ID, model.LabelForURL, model.LabelForMenu, model.Title,
                                              model.MetaDescription, model.MetaKeywords, model.ParentID, model.Content,
                                              model.MenuWeight, model.IsMenu, model.IsRemove, model.DateCreation);
                    }
                    //найти страницы, в которых участвует изменяемая страница
                    var pages = repository.GetPagesByParentId(model.ID).ToList();
                    foreach (var page in pages)
                    {
                        string[] urlArr = page.LabelForURL.Split('/');
                        //изменить родительский адрес на переименованный
                        urlArr[urlArr.Length - 2] = model.LabelForURL;
                        //собрать новый url
                        string newUrl = String.Join("/", urlArr);
                        repository.UpdatePage(page.ID, newUrl, page.LabelForMenu, page.Title, page.MetaDescription,
                                              page.MetaKeywords, page.ParentID, page.Content, page.MenuWeight,
                                              page.IsMenu, page.IsRemove, page.DateCreation);
                    }
                    return RedirectToAction("Pages");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// сюда приходит запрос и смотри есть ли вложенные страницы, если есть , то они отправляются в модальное окно
        /// </summary>
        /// <param name="id">id удаляемой страницы</param>
        /// <returns></returns>
        public ActionResult DeleteAjax(int id)
        {
            if (Request.IsAjaxRequest())
            {
                var pages = repository.GetPagesByParentId(id).ToList();
                if (pages.Count != 0)
                {
                    //там частичное представление, которое вставляю в модальное окно
                    return PartialView(pages);
                }
            }
            //нет вложенных страниц - нечего возвращать
            return null;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var childPages = repository.GetPagesByParentId(id).ToList();
                if (childPages.Count != 0)
                {
                    foreach (var childPage in childPages)
                    {
                        childPage.IsRemove = true;
                        repository.UpdatePage(childPage.ID, childPage.LabelForURL, childPage.LabelForMenu, childPage.Title, childPage.MetaDescription, childPage.MetaKeywords, childPage.ParentID, childPage.Content, childPage.MenuWeight, childPage.IsMenu, childPage.IsRemove, childPage.DateCreation);
                    }
                }
                var selectedPage = repository.Get(id);
                selectedPage.IsRemove = true;
                repository.UpdatePage(selectedPage.ID, selectedPage.LabelForURL, selectedPage.LabelForMenu, selectedPage.Title, selectedPage.MetaDescription, selectedPage.MetaKeywords, selectedPage.ParentID, selectedPage.Content, selectedPage.MenuWeight, selectedPage.IsMenu, selectedPage.IsRemove, selectedPage.DateCreation);
                return RedirectToAction("Pages");
            }
            catch
            {
                throw new Exception("remove elem error");
            }
        }

        #endregion PAGE

        #region COMPONENT

        public ActionResult Components()
        {

            var components = componentRepository.GetAll();
            List<ComponentModel> model = new List<ComponentModel>();
            foreach (var c in components) model.Add(c);
            return View(model);
        }

        public ActionResult CreateComponent()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateComponent(ComponentModel model)
        {
            try
            {
                componentRepository.CreateComponent(model.Name, model.Label, model.Content);
                return RedirectToAction("Components");
            }
            catch
            {
                return RedirectToAction("Components");
            }
        }

        public ActionResult UpdateComponent(int id)
        {
            return View((ComponentModel)componentRepository.Get(id));
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateComponent(ComponentModel model)
        {
            try
            {
                componentRepository.UpdateComponent(model.Id, model.Name, model.Label, model.Content);
                return RedirectToAction("Components");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteComponent(int id)
        {
            componentRepository.Remove(id);
            return RedirectToAction("Components");
        }

        #endregion COMPONENT

        #region TEMPLATE

        public ActionResult Templates()
        {
            InitTemplates();
            List<TemplateModel> model = new List<TemplateModel>();
            var tmpls = templateRepository.GetAll();
            foreach (var t in tmpls) model.Add(t);
            return View(model);
        }

        public ActionResult CreateTemplate()
        {
            //получение списка компонентов
            var components = componentRepository.GetAll().ToList();
            List<ComponentModel> listComponents = new List<ComponentModel>();
            foreach (var c in components) listComponents.Add(c);
            return View(new TemplateModel(Server.MapPath("\\Views\\Shared\\BaseTemplate\\"), listComponents));
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateTemplate(TemplateModel model)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("\\Views\\Shared\\" + model.Name + ".cshtml");
                string content = GetLayoutContent(model.Content);
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8))
                {
                    streamWriter.Write(content);
                }
                return RedirectToAction("Templates");
            }
            return View(model);
        }

        public ActionResult UpdateTemplate(int id)
        {
            //получение списка компонентов
            var components = componentRepository.GetAll().ToList();
            List<ComponentModel> listComponents = new List<ComponentModel>();
            foreach (var c in components) listComponents.Add(c);
            //получение шаблонов
            var templ = templateRepository.Get(id);
            TemplateModel model = new TemplateModel(templ.Id, templ.Name, Server.MapPath("\\Views\\Shared\\"),listComponents);
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateTemplate(TemplateModel model)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("\\Views\\Shared\\" + model.Name + ".cshtml");
                string content = GetLayoutContent(model.Content);
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8))
                {
                    streamWriter.Write(content);
                }
                return RedirectToAction("Templates");
            }
            return View(model);
        }
        #region privateMethTemplate



        /// <summary>
        /// поиск по папкам шаблонов и загрузка их имен в БД
        /// </summary>
        private void InitTemplates()
        {
            string[] tmplPaths = Directory.GetFiles(Server.MapPath("\\Views\\Shared"));
            foreach (var path in tmplPaths)
            {
                string tmplName = path.Split('\\').Last().Split('.').First();
                if (templateRepository.GetByName(tmplName) == null)
                    templateRepository.CreateTemplate(tmplName);
            }
        }
        /// <summary>
        /// метод  парсит контент и заменяет <<xxx>> в @Html.GetComponents("xxx")
        /// </summary>
        /// <param name="content">контент от пользователя</param>
        /// <returns></returns>
        private string GetLayoutContent(string source)
        {
            string pattern = "<<[a-zA-Z]*>>";
            while (Regex.IsMatch(source, pattern))
            {
                Match match = Regex.Match(source, pattern);
                //вырезать имя компонента между 2 <<  и  >>
                string componentName = match.Value.Substring(2, match.Length - 4);
                string oldString = source.Substring(match.Index, match.Length);
                source = source.Replace(oldString, "@Html.GetComponent(\"" + componentName + "\")");
            }
            return source;
        }
        #endregion privateMethTemplate

        #endregion TEMPLATE

    }
}
