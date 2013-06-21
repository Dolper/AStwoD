using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.Models
{
    public class ComponentModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название компонента (англ)")]
        public string Name { get; set; }
        [Display(Name = "Название компонента (рус)")]
        public string Label { get; set; }
        [Display(Name = "Контент")]
        public string Content { get; set; }

        public ComponentModel() { }

        public ComponentModel(int id, string name, string label, string content)
        {
            Id = id;
            Name = name;
            Label = label;
            Content = content;
        }

        public static implicit operator ComponentModel(Component op)
        {
            return new ComponentModel(op.ID, op.Name, op.Label, op.Content);
        }

    }
}