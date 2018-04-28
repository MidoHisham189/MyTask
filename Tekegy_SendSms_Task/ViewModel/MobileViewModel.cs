using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tekegy_SendSms_Task.Models;
namespace Tekegy_SendSms_Task.ViewModel
{
    public class MobileViewModel
    {
        public Mobile mobile { get; set; }
        public IEnumerable<Category> Gategories { get; set; }
    }
}