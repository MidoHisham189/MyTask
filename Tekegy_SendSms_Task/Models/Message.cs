using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tekegy_SendSms_Task.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required]
        [MaxLength(11)]
        public string MessageTitle { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SentTime { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Range(0, 10)]
        public double MessageCost { get; set; }

        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }

        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}