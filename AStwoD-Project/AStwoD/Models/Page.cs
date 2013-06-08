using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.Models
{
    public class Page
    {
        public Page()
        {

        }

        public Page(String name, String title,String metaK, String metaD, Int32? parentID, String link,String content)
        {
            Name = name;
            Title = title;
            ParentID = parentID;
            Link = link;
            MetaD = metaD;
            MetaK = metaK;
            Content = content;
        }

        public static implicit operator Page(astwod_Page op1)
        {
            if (op1 != null)
                return new Page(op1.Name, op1.Title, op1.MetaK, op1.MetaD, op1.ParentID, op1.Link, op1.Content);
            else return new Page();
        }

        [Display(Name="Имя для адресной строки")]
        [Required(ErrorMessage="Поле не может быть пустым")]
        public String Name { get; set; }
        [Display(Name = "Заголовок страницы")]
        public String Title { get; set; }
        [Display(Name = "Ссылка для отображения в меню")]
        public String Link { get; set; }
        [Display(Name = "Ссылка на страницу родителя")]
        public Int32? ParentID{get; set;}
        [Display(Name = "Содержимое страницы")]
        public String Content{get; set;}
        [Display(Name = "MetaDescription")]
        public String MetaD { get; set; }
        [Display(Name = "MetaKey")]
        public String MetaK {get;set;}
        [HiddenInput(DisplayValue=false)]
        public int ID { get; set; }
    }
}