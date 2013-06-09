using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AStwoD.Models
{
    public class RequestRepairModel
    {
        public string City { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public RequestRepairModel(string city,string fio, string phone,string message)
        {
            City = city;
            FIO = fio;
            Phone = phone;
            Message = message;
        }

        public RequestRepairModel(){}
    }
}