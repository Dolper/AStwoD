using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.Models
{
    public class TemplateModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Display(Name = "Имя шаблона")]
        public string Name { get; set; }
        public string Content { get; set; }

        public TemplateModel() { }

        public TemplateModel(int id, string name, string path)
        {
            ID = id;
            Name = name;
            try
            {
                using (StreamReader sr = new StreamReader(path + name + ".cshtml"))
                {
                    Content = sr.ReadToEnd();
                }
            }
            catch
            {

            }
        }

        public static implicit operator TemplateModel(Template op)
        {
            return new TemplateModel(op.Id, op.Name,null);
        }

    }
}