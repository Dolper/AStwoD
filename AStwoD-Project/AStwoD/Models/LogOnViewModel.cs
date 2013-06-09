using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AStwoD.Models
{
    public class LogOnViewModel
    {
        [Required]
        [Display(Name="Логин")]
        public String UserName { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}