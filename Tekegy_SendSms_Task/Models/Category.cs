using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tekegy_SendSms_Task.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public double CategoryBalance { get; set; }

        public double price { get; set; }
    }
}