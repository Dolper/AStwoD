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

        public FeedBackModel(string fio, string phone,string message)
        {
            FIO = fio;
            Phone = phone;
            Message = message;
        }

        public FeedBackModel(){}
    }
}