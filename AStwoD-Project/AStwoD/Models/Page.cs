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

        [Display(Name = "Имя для адресной строки")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public String LabelForURL { get; set; }
        [Display(Name = "Заголовок страницы")]
        public String Title { get; set; }
        [Display(Name = "Ссылка для отображения в меню")]
        public String LabelForMenu { get; set; }
        [Display(Name = "Ссылка на страницу родителя")]
        public Int32? ParentID { get; set; }
        [Display(Name = "Содержимое страницы")]
        public String Content { get; set; }
        [Display(Name = "MetaDescription")]
        public String MetaD { get; set; }
        [Display(Name = "MetaKey")]
        public String MetaK { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Display(Name = "Является ли страница меню?")]
        public bool IsMenu { get; set; }
        [Display(Name = "Вес меню")]
        public byte? MenuWeight { get; set; }

        public IEnumerable<SelectListItem> parents { get; set; } 

        public Page()
        {
            parents = new List<SelectListItem>();
        }

        public Page(String labelForURL, String title,String metaK, String metaD, Int32? parentID, String labelForMenu,String content,bool isMenu,byte? menuWeight):this()
        {
            LabelForURL = labelForURL;
            Title = title;
            ParentID = parentID;
            LabelForMenu = labelForMenu;
            MetaD = metaD;
            MetaK = metaK;
            Content = content;
            IsMenu = isMenu;
            MenuWeight = menuWeight;
        }

        public static implicit operator Page(astwod_Page op1)
        {
            if (op1 != null)
                return new Page(op1.LabelForURL, op1.Title, op1.MetaK, op1.MetaD, op1.ParentID, op1.LabelForMenu, op1.Content,op1.IsMenu,op1.MenuWeight);
            else return new Page();
        }

 
    }
}