using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.Models;

namespace AStwoD.Infrastructure.Concrete
{
    public class BasketPages
    {
        public List<PageModel> basketPages;
        public List<ArticleModel> basketArticles;

        public BasketPages() 
        {
            basketPages = new List<PageModel>();
            basketArticles = new List<ArticleModel>();
        }
    }
}