using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.Models;

namespace AStwoD.Infrastructure.Concrete
{
    public class BasketPages
    {
        public List<PageModel> basket;

        public BasketPages() 
        {
            basket = new List<PageModel>();
        }
    }
}