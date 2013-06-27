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
        [Required(ErrorMessage = "Имя шаблона необходимо указать!")]
        public string Name { get; set; }
        [Display(Name = "Содержимое шаблона")]
        [Required(ErrorMessage = "Содержимое шаблона не может быть пустым!")]
        public string Content { get; set; }

        public List<ComponentModel> Components { get; set; }

        public TemplateModel()
        {
            Components = new List<ComponentModel>();
        }

        /// <summary>
        /// при заполнении коллекции компонентов для шаблона
        /// </summary>
        /// <param name="components"></param>
        private TemplateModel(List<ComponentModel> components)
            : this()
        {
            Components = components;
        }

        /// <summary>
        /// использовать при создании шаблона
        /// </summary>
        /// <param name="path">путь до файла с шаблоном</param>
        public TemplateModel(string path, List<ComponentModel> components)
            : this(components)
        {
            ID = 0;
            Name = "";
            if (path != null)
            {
                using (StreamReader sr = new StreamReader(path + "BaseTemplate.cshtml"))
                {
                    Content = GetContentToShow(sr.ReadToEnd());
                }
            }
        }
        /// <summary>
        /// использовать при приведении типов при загрузке списка шаблонов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TemplateModel(int id, string name)
            : this()
        {
            ID = id;
            Name = name;
        }
        /// <summary>
        /// использовать при редактировании шаблонов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="components"></param>
        public TemplateModel(int id, string name, string path, List<ComponentModel> components)
            : this(components)
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
            string pattern = "@Html.GetComponent\\(\"[\\w]*[-]*[\\w]*\"\\)";
            while (Regex.IsMatch(source, pattern))
            {
                Match match = Regex.Match(source, pattern);
                //сместим стартовый индекс нахождения на длину выражения @Html.GetComponents("
                int dx = "@Html.GetComponent(\"".ToCharArray().Length;
                //вырезаем имя компонента из строчки-хелпера, длину уменьшим на 2, чтобы не вырезать подстроку    ")
                string componentName = match.Value.Substring(dx, match.Length - dx - 2);
                string oldString = source.Substring(match.Index, match.Length);
                source = source.Replace(oldString, "[[" + componentName + "]]");
            }
            return source;
        }

        public static implicit operator TemplateModel(Template op)
        {
            return new TemplateModel(op.Id, op.Name);
        }

    }
}