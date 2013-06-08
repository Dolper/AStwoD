using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.Models
{
    public class Page
    {
        public Page()
        {

        }

        public Page(String name, String title, Int32? parentID, String link)
        {
            Name = name;
            Title = title;
            ParentID = parentID;
            Link = link;
        }

        public static implicit operator Page(astwod_Page op1)
        {
            return new Page(op1.Name, op1.Title, op1.ParentID, op1.Link);
        }

        public String Name { get; set; }
        public String Title { get; set; }
        public String Link { get; set; }
        public Int32? ParentID{get; set;}
        public String Content{get; set;}
    }
}