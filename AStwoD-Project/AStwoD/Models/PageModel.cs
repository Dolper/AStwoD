using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.Models
{
    public class PageModel
    {

        [Display(Name = "Имя для адресной строки")]
        [RegularExpression("[\\w]*[-]*[\\w]*", ErrorMessage = "Неверное имя для адресной строки!")]
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
        public String MetaDescription { get; set; }
        [Display(Name = "MetaKeywords")]
        public String MetaKeywords { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Display(Name = "Является ли страница меню?")]
        public bool IsMenu { get; set; }
        [Display(Name = "Вес меню")]
        public byte? MenuWeight { get; set; }
        public bool IsRemove { get; set; }

        private DateTime dateCreation = DateTime.MinValue;
        [Display(Name = "Дата создания страницы")]
        public DateTime DateCreation
        {
            get { return (dateCreation == DateTime.MinValue) ? DateTime.Now : dateCreation; }
            set { dateCreation = value; }
        }

        public IEnumerable<SelectListItem> parents { get; set; }

        public PageModel()
        {
            parents = new List<SelectListItem>();
        }

        public PageModel(String labelForURL, String title, String metaKeywords, String metaDescription, Int32? parentID, String labelForMenu, String content, bool isMenu, byte? menuWeight, bool isRemove, DateTime dateCreation)
            : this()
        {
            LabelForURL = labelForURL;
            Title = title;
            ParentID = parentID;
            LabelForMenu = labelForMenu;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            Content = content;
            IsMenu = isMenu;
            MenuWeight = menuWeight;
            IsRemove = isRemove;
            DateCreation = dateCreation;
        }

        public static implicit operator PageModel(astwod_Page op1)
        {
            if (op1 != null)
                return new PageModel(op1.LabelForURL, op1.Title, op1.MetaKeywords, op1.MetaDescription, op1.ParentID, op1.LabelForMenu, op1.Content, op1.IsMenu, op1.MenuWeight, op1.IsRemove, op1.DateCreation);
            else return new PageModel();
        }


    }
}