using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AStwoD.Models
{
    public class FileModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; private set; }
        [Display(Name = "Имя картинки")]
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Path { get; set; }

        public FileModel() { }

        public FileModel(string name, string path)
        {
            Name = name;
            Path = path;
            ID = GetNextID();
        }

        ~FileModel()
        {
            counter--;
        }

        private static int counter=0;

        private int GetNextID()
        {
            return counter++;
        }
    }
}