using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Tekegy_SendSms_Task.Models;
using System.Data.Entity;
using Tekegy_SendSms_Task.ViewModel;
namespace Tekegy_SendSms_Task.Controllers
{
    public class UserMessagesController : Controller
    {
        private ApplicationDbContext db;

        public UserMessagesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: UserMessages
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Status(){
            string UserId = User.Identity.GetUserId();

            int? MobileId = db.mobiles.FirstOrDefault(m => m.UserId == UserId)
                .MobileId;
            if (MobileId == null)
            {
                return View();
            }

            var message = db.messages
                .Include(m=> m.Recipients)
                .Where(m => m.MobileId == MobileId);

            return View(message);
        }

        [Authorize]
        public ActionResult Report()
        {
            
            string UserId = User.Identity.GetUserId();

            int MobileId = db.mobiles.FirstOrDefault(m => m.UserId == UserId)
                .MobileId;


           var messages = from m in db.messages
                           where m.MobileId == MobileId
                           join mob in db.mobiles
                           on m.MobileId equals mob.MobileId
                           join reci in db.recipients
                           on m.MessageID equals reci.MessageId
                           select new ReportViewModel
                           {
                               MessageID = m.MessageID,
                               MobileNumber = mob.MobileNumber,
                               SentTime = m.SentTime,
                               MessageText = m.MessageText,
                               MessageCost = m.MessageCost,
                               MessageStatus = reci.MessageStatus

                           };
                              
                          
                          

            return View(messages);
        }


        [Authorize]
        [HttpGet]
        public ActionResult GetBalance()
        {
           string UserId = User.Identity.GetUserId();
            var MobileId = db.mobiles.FirstOrDefault(m => m.UserId == UserId)
                .MobileId;
            return View(MobileId);
        }
    }
}