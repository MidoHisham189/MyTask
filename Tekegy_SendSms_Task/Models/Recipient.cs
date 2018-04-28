using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tekegy_SendSms_Task.Models
{
    public class Recipient
    {
        public int RecipientId { get; set; }
        [Required]
        public string MessageStatus { get; set; }

        [Required]
        public int RecipientNumber { get; set; }


        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}