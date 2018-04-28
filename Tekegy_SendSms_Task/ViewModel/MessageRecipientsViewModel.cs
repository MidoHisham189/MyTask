using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tekegy_SendSms_Task.Models;
namespace Tekegy_SendSms_Task.ViewModel
{
    public class MessageRecipientsViewModel
    {
      public string  MessageText {get; set;}
      public string MessageTitle { get; set; }
      public List<Recipient> Recipients { get; set; }
    }
}