using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AStwoD.Models
{
    public class Page
    {
        public Page()
        {

        }

        public Page(String name, String title, Int32 parentID, String link)
        {
            Name = name;
            Title = title;
            ParentID = parentID;
            Link = link;
        }

        public String Name { get; set; }
        public String Title { get; set; }
        public String Link { get; set; }
        public Int32 ParentID{get; set;}
        public String Content{get; set;}
    }
}