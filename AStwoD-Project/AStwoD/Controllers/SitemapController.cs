using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.Classes;
using AStwoD.DAL.Repositories;

namespace AStwoD.Controllers
{
    public class SitemapController : Controller
    {
        private PageRepository repository;
        public SitemapController()
        {
            repository = new PageRepository();
        }
      
        public XmlSitemapResult Index()
        {
            var items = new List<ISiteMapItem>();
            var pages = repository.GetAll();

            foreach (var page in pages)
            {
                items.Add(new SiteMapItem(System.Web.HttpContext.Current.Request.Url.Authority+"/" + page.LabelForURL) { Priority = 1 });
            }
            return new XmlSitemapResult(items);
        }

    }
}
