using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (path != null)
            {
                using (StreamReader sr = new StreamReader(path + name + ".cshtml"))
                {
                    Content = GetContentToShow(sr.ReadToEnd());
                }
            }

        }

        private string GetContentToShow(string source)
        {
            string pattern = "@Html.GetComponent\\(\"[a-zA-Z]*\"\\)";
            while (Regex.IsMatch(source, pattern))
            {
                Match match = Regex.Match(source, pattern);
                //сместим стартовый индекс нахождения на длину выражения @Html.GetComponents("
                int dx = "@Html.GetComponent(\"".ToCharArray().Length;
                //вырезаем имя компонента из строчки-хелпера, длину уменьшим на 2, чтобы не вырезать подстроку    ")
                string componentName = match.Value.Substring(dx, match.Length - dx - 2);
                string oldString = source.Substring(match.Index, match.Length);
                source = source.Replace(oldString, "<<" + componentName + ">>");
            }
            return source;
        }

        public static implicit operator TemplateModel(Template op)
        {
            return new TemplateModel(op.Id, op.Name, null);
        }

    }
}