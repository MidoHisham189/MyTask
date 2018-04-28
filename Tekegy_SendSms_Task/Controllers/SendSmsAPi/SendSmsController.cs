using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Tekegy_SendSms_Task.Models;
using System.Data.Entity.Validation;
using Tekegy_SendSms_Task.ViewModel;

namespace Tekegy_SendSms_Task.Controllers.SendSmsAPi
{
    [RoutePrefix("api/Sms")]
    public class SendSmsController : ApiController
    {
                private ApplicationDbContext db;

        private SendSmsController()
        {
            db = new ApplicationDbContext();
        }
        [Authorize]
        [Route("Send")]
        public IHttpActionResult Post(MessageRecipientsViewModel MessageVm)
        {
            try
            {
                string UserId = User.Identity.GetUserId();
                var Mobile = db.mobiles
                    .Include(u => u.User)
                    .FirstOrDefault(m => m.UserId == UserId);

            

                double currentBalance = Mobile.Balance;
                if (Mobile == null)
                {
                    return BadRequest();
                }


                Message message = new Message()
                {
                    MessageCost = 1,
                    MessageText = MessageVm.MessageText,
                    MessageTitle = MessageVm.MessageTitle,
                    MobileId = Mobile.MobileId,
                    SentTime = DateTime.Now,

                };
                db.messages.Add(message);
                db.SaveChanges();



                foreach (var recipient in MessageVm.Recipients)
                {
                    if (currentBalance < 1)
                    {
                        recipient.MessageStatus = "Not Sent";
                        db.recipients.Add(recipient);

                    }
                    else
                    {
                        recipient.MessageStatus = "Sent";
                        recipient.MessageId = message.MessageID;
                        db.recipients.Add(recipient);
                        currentBalance = currentBalance - 1;


                    }

                }

                Mobile.Balance = currentBalance;
                db.SaveChanges();

                return Ok(message.MessageID);
            }

            catch (DbEntityValidationException ex)
            {
                return Ok(ex);
            }
            
            
                
                   

            
        }

        [Authorize]
        [Route("GetStatus")]
        public IHttpActionResult GetStatus(int? MessageId)
        {
            if (MessageId == null)
            {
                return BadRequest();
            }

            var MessageDetails = db.recipients
                .Include(r => r.Message)
                .FirstOrDefault(m => m.MessageId == MessageId);

            return Ok(MessageDetails);
        }

        
        [Authorize]
        [Route("balance")]
        public IHttpActionResult GetBalance(int? MobileId)
        {
            if (MobileId == null)
            {
                return BadRequest();
            }

            var Mobile = db.mobiles
                .Include(m => m.User)
             .FirstOrDefault(m => m.MobileId == MobileId);

            return Ok(Mobile.Balance);

        }

        [Authorize]
        public IHttpActionResult AddNumber(Mobile mobile)
        {
            try
            {
                mobile.UserId = User.Identity.GetUserId();
                db.mobiles.Add(mobile);
                db.SaveChanges();
                return Ok(mobile);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

