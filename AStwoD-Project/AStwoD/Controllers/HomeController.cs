using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AStwoD.Classes;
using AStwoD.DAL.Entity_First_Model;
using AStwoD.DAL.Repositories;
using AStwoD.Models;

namespace AStwoD.Controllers
{
    public class HomeController : Controller
    {

        private PageRepository repository;
        private MenuRepository menuRepository;
        private ArticleRepository articleRepository;

        public HomeController()
        {
            articleRepository = new ArticleRepository();
            repository = new PageRepository();
            menuRepository = new MenuRepository();
        }

        public ActionResult Index(string labelForURL)
        {
            labelForURL = labelForURL ?? "index";
            if (labelForURL != "index")
            {
                if (repository.GetPageByName(labelForURL)==null)
                {
                    if (articleRepository.GetArticleByURL(labelForURL) == null)
                    {
                        return View((PageModel)repository.GetPageByName("404"));
                    }
                    else
                    {
                        return View((PageModel)articleRepository.GetArticleByURL(labelForURL));
                    }
                }
            }
            return View((PageModel)(repository.GetPageByName(labelForURL)));
        }

        public ActionResult Articles()
        {
            IEnumerable<Article> allArticles = articleRepository.GetAll();
            List<ArticleModel> articles = new List<ArticleModel>();
            foreach (var a in allArticles) articles.Add(a);
            return View(articles);
        }

        public ActionResult GetMenu()
        {
            var model = menuRepository.GetAll();
            return PartialView(model);
        }
    }
}
