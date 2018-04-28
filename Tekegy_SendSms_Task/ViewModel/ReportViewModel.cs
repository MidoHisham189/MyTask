using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tekegy_SendSms_Task.ViewModel
{
    public class ReportViewModel
    {
        public int MessageID {get; set;}

        public int MobileNumber {get; set;}

        public DateTime SentTime {get; set;}

        public string MessageText {get; set;}
        public double MessageCost {get; set;}
        public string MessageStatus { get; set; }
    }
}