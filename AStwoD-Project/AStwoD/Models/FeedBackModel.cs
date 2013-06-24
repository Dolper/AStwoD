using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AStwoD.Models
{
    public class FeedBackModel
    {
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }

        public FeedBackModel(string fio, string phone,string message)
        {
            FIO = fio;
            Phone = phone;
            Message = message;
        }

        public FeedBackModel(){}
    }
}