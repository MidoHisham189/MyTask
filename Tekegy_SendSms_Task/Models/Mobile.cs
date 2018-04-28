using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tekegy_SendSms_Task.Models
{
    public class Mobile
    {
        public int MobileId { get; set; }
        [Required]
        
        public int MobileNumber { get; set; }

        [Required]
        public double Balance { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CtegoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Message> messages { get; set; }
    }
}