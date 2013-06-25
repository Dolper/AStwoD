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
using AStwoD.Infrastructure.Concrete;
using AStwoD.Models;
using Newtonsoft.Json;
using Ninject;
using PagedList;

namespace AStwoD.Controllers
{
    public partial class ControlPanelController : Controller
    {
        private PageRepository repository;
        private ComponentRepository componentRepository;
        private TemplateRepository templateRepository;
        private ArticleRepository articleRepository;
        private BasketPages bp;

        public ControlPanelController()
        {
            repository = new PageRepository();
            componentRepository = new ComponentRepository();
            templateRepository = new TemplateRepository();
            articleRepository = new ArticleRepository();
            bp = new BasketPages();
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
                        list.Add(item);
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
            List<astwod_Page> allpages = repository.GetAll().ToList();
            List<PageModel> pages = new List<PageModel>();
            foreach (var item in allpages)
            {
                if (item.IsRemove != true)
                {
                    pages.Add(item);
                }
            }
            return View(pages.ToPagedList(pageIndex, pageSize));
        }

        [Authorize(Roles = "SEO")]
        public ActionResult PagesForSEO(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<astwod_Page> allpages = repository.GetAll().ToList();
            List<PageModel> pages = new List<PageModel>();
            foreach (var item in allpages)
            {
                if (item.IsRemove != true)
                {
                    pages.Add(item);
                }
            }
            return View(pages.ToPagedList(pageIndex, pageSize));
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
                repository.UpdatePage(model.ID, model.LabelForURL, model.LabelForMenu, model.Title, model.MetaDescription, model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight, model.IsMenu, model.IsRemove, model.DateCreation, model.TemplateId);
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
            List<astwod_Page> selectListPages = new List<astwod_Page>();
            foreach (var page in allPages) if (!page.IsRemove) selectListPages.Add(page);
            model.parents = new SelectList(selectListPages, "ID", "LabelForURL");

            var allTempl = templateRepository.GetAll();
            List<Template> selectListTemplates = new List<Template>();
            foreach (var tmpl in allTempl) selectListTemplates.Add(tmpl);
            model.templates = new SelectList(selectListTemplates, "Id", "Name");

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
                                              model.IsMenu, DateTime.Now, model.TemplateId);
                    }
                    else
                    {
                        repository.CreatePage(model.LabelForURL, model.LabelForMenu, model.Title, model.MetaDescription,
                                              model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight,
                                              model.IsMenu, model.DateCreation, model.TemplateId);
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


        [Authorize(Roles = "Admin")]
        public ActionResult Basket(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<astwod_Page> removedPages = repository.GetRemovedPages().ToList();
            foreach (var item in removedPages)
            {
                if (item.IsRemove)
                {
                    bp.basketPages.Add(item);
                }
            }
            return View(bp.basketPages.ToPagedList(pageIndex, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RecoveryPages(int id)
        {
            astwod_Page currentPage = repository.Get(id);
            currentPage.IsRemove = false;
            repository.UpdatePage(currentPage.ID, currentPage.LabelForURL, currentPage.LabelForMenu, currentPage.Title, currentPage.MetaDescription, currentPage.MetaKeywords, currentPage.ParentID, currentPage.Content, currentPage.MenuWeight, currentPage.IsMenu, currentPage.IsRemove, currentPage.DateCreation, currentPage.TemplateID);
            return RedirectToAction("Basket");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id)
        {
            var model = (PageModel)repository.Get(id);
            model.LabelForURL = model.LabelForURL.Split('/').Last();

            var allPages = repository.GetAll();
            List<astwod_Page> selectListPages = new List<astwod_Page>();
            foreach (var page in allPages) if (!page.IsRemove) selectListPages.Add(page);
            model.parents = new SelectList(selectListPages, "ID", "LabelForURL");

            var allTempl = templateRepository.GetAll();
            List<Template> selectListTemplates = new List<Template>();
            foreach (var tmpl in allTempl) selectListTemplates.Add(tmpl);
            model.templates = new SelectList(selectListTemplates, "Id", "Name");

            return View(model);
        }

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
                    url += model.ParentID > 0 ? "/" + model.LabelForURL.Split('/').Last() : "";
                    repository.UpdatePage(model.ID, url, model.LabelForMenu, model.Title, model.MetaDescription,
                                          model.MetaKeywords, model.ParentID, model.Content, model.MenuWeight,
                                          model.IsMenu, model.IsRemove, model.DateCreation, model.TemplateId);
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
                                              page.IsMenu, page.IsRemove, page.DateCreation, page.TemplateID);
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
                List<astwod_Page> childs = new List<astwod_Page>();
                GetChilds(repository.Get(id), ref childs);
                if (childs.Count != 0)
                {
                    //там частичное представление, которое вставляю в модальное окно
                    return PartialView(childs);
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
                List<astwod_Page> childs = new List<astwod_Page>();
                GetChilds(repository.Get(id), ref childs);
                if (childs.Count != 0)
                {
                    foreach (var childPage in childs)
                    {
                        childPage.IsRemove = true;
                        repository.UpdatePage(childPage.ID, childPage.LabelForURL, childPage.LabelForMenu, childPage.Title, childPage.MetaDescription, childPage.MetaKeywords, childPage.ParentID, childPage.Content, childPage.MenuWeight, childPage.IsMenu, childPage.IsRemove, childPage.DateCreation, childPage.TemplateID);
                    }
                }
                var selectedPage = repository.Get(id);
                selectedPage.IsRemove = true;
                repository.UpdatePage(selectedPage.ID, selectedPage.LabelForURL, selectedPage.LabelForMenu, selectedPage.Title, selectedPage.MetaDescription, selectedPage.MetaKeywords, selectedPage.ParentID, selectedPage.Content, selectedPage.MenuWeight, selectedPage.IsMenu, selectedPage.IsRemove, selectedPage.DateCreation, selectedPage.TemplateID);
                return RedirectToAction("Pages");
            }
            catch
            {
                throw new Exception("remove elem error");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeletePageFromBasket(int id)
        {
            repository.Remove(id);
            return RedirectToAction("Basket");
        }

        #region privateMethPage
        /// <summary>
        /// поиск всех детей, включая вложенные
        /// </summary>
        /// <param name="parentPage">родительский узел</param>
        /// <param name="childs">коллекция всех детей</param>
        private void GetChilds(astwod_Page parentPage, ref List<astwod_Page> childs)
        {
            var pages = repository.GetAll().ToList();
            foreach (astwod_Page page in pages)
            {
                //поиск по родителю и не удаленным страницам
                if ((page.ParentID == parentPage.ID) && (!page.IsRemove))
                {
                    GetChilds(page, ref childs);
                    childs.Add(page);
                }
            }
        }

        #endregion privateMethPage

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
            TemplateModel model = new TemplateModel(templ.Id, templ.Name, Server.MapPath("\\Views\\Shared\\"), listComponents);
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
                return Json(new { url = Url.Action("Templates") }, JsonRequestBehavior.AllowGet);
            }
            return View(model);
        }

        public ActionResult DeleteTemplate(int id)
        {
            try
            {
                templateRepository.Remove(id);
            }
            catch (Exception)
            {
                return RedirectToAction("Templates");
            }
            return RedirectToAction("Templates");
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
        /// метод  парсит контент и заменяет [[xxx]] в @Html.GetComponents("xxx")
        /// </summary>
        /// <param name="content">контент от пользователя</param>
        /// <returns></returns>
        private string GetLayoutContent(string source)
        {
            string pattern = @"[[[\w]*[-]*[\w]*]]";
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

        #region ARTICLE


        [Authorize(Roles = "Admin")]
        public ActionResult AllArticles(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<Article> allArticles = articleRepository.GetAll().ToList();
            List<ArticleModel> articles = new List<ArticleModel>();
            foreach (var item in allArticles)
            {
                if (item.IsRemove != true)
                {
                    articles.Add(item);
                }
            }
            return View(articles.ToPagedList(pageIndex, pageSize));
        }

        [Authorize(Roles = "SEO")]
        public ActionResult AllArticlesSEO(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<Article> allArticles = articleRepository.GetAll().ToList();
            List<ArticleModel> articles = new List<ArticleModel>();
            foreach (var item in allArticles)
            {
                if (item.IsRemove != true)
                {
                    articles.Add(item);
                }
            }
            return View(articles.ToPagedList(pageIndex, pageSize));
        }

        [Authorize(Roles = "SEO")]
        public ActionResult UpdateArticleSEO(int id)
        {
            var model = (ArticleModel)articleRepository.Get(id);
            return View(model);
        }

        [Authorize(Roles = "SEO")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateArticleSEO(Article model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    articleRepository.UpdateArticleByID(model.ID, model.Title, model.Preview, model.Content, model.URL, model.MetaKeywords, model.MetaDescription, model.PublicationDate, model.IsRemove);
                    return RedirectToAction("AllArticlesSEO");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult BasketArticles(int? page)
        {
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            List<Article> removedArticles = articleRepository.GetAll().ToList();
            foreach (var item in removedArticles)
            {
                if (item.IsRemove == true)
                {
                    bp.basketArticles.Add(item);
                }
            }
            return View(bp.basketArticles.ToPagedList(pageIndex, pageSize));
        }


        [Authorize(Roles = "Admin")]
        public ActionResult RecoveryArticle(int id)
        {
            Article currentArticle = articleRepository.Get(id);
            currentArticle.IsRemove = false;
            articleRepository.UpdateArticleByID(currentArticle.ID, currentArticle.Title, currentArticle.Preview, currentArticle.Content, currentArticle.URL, currentArticle.MetaKeywords, currentArticle.MetaDescription, currentArticle.PublicationDate, currentArticle.IsRemove);
            return RedirectToAction("AllArticles");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult CreateArticle()
        {
            var model = new ArticleModel();
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateArticle(ArticleModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    articleRepository.CreateArticle(model.Title, model.Preview, model.Content, model.URL, model.MetaKeywords,
                                          model.MetaDescription, model.PublicationDate, model.IsRemove);
                    return RedirectToAction("AllArticles");
                }
                return View(model);
            }
            catch
            {
                //throw new Exception("Невозможно добавить страницу");
                return View();
            }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult ArticleDetails(int id)
        {
            return RedirectToAction("Index", "Controller", new { labelForURL = articleRepository.Get(id).URL });
        }


        [Authorize(Roles = "Admin")]
        public ActionResult UpdateArticle(int id)
        {
            var model = (ArticleModel)articleRepository.Get(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateArticle(Article model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    articleRepository.UpdateArticleByID(model.ID, model.Title, model.Preview, model.Content, model.URL, model.MetaKeywords, model.MetaDescription, model.PublicationDate, model.IsRemove);
                    return RedirectToAction("AllArticles");
                }
                return View(model);
            }
            catch
            {
                return View();
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteArticle(int id)
        {
            Article selectedArticle = articleRepository.Get(id);
            selectedArticle.IsRemove = true;
            articleRepository.UpdateArticleByID(selectedArticle.ID, selectedArticle.Title, selectedArticle.Preview, selectedArticle.Content, selectedArticle.URL, selectedArticle.MetaKeywords, selectedArticle.MetaDescription, selectedArticle.PublicationDate, selectedArticle.IsRemove);
            return RedirectToAction("AllArticles");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteArticleFromBasket(int id)
        {
            articleRepository.Remove(id);
            return RedirectToAction("BasketArticles");
        }

        #endregion
    }
}
