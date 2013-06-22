using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AStwoD.Models
{
    public class PictureModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Display(Name = "Имя картинки")]
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Path { get; set; }

        public PictureModel() { }

        public PictureModel(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}