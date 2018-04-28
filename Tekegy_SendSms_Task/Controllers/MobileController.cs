using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekegy_SendSms_Task.ViewModel;
using Tekegy_SendSms_Task.Models;
using Microsoft.AspNet.Identity;
namespace Tekegy_SendSms_Task.Controllers
{
    public class MobileController : Controller
    {
        private ApplicationDbContext db;

        public MobileController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Mobile
        public ActionResult Create()
        {
            MobileViewModel MobileVm = new MobileViewModel()
            {
                Gategories = db.Categories,
                mobile = new Mobile()
            };
            return View(MobileVm);
        }


        [HttpPost]
        public ActionResult Create(MobileViewModel mob)
        {
            Mobile mobile = new Mobile();
            mobile.UserId = User.Identity.GetUserId();
            mobile.MobileNumber = mob.mobile.MobileNumber;
            mobile.CtegoryId = mob.mobile.CtegoryId;
            mobile.Balance = db.Categories.SingleOrDefault(x => x.CategoryId == mob.mobile.CtegoryId).CategoryBalance;
            db.mobiles.Add(mobile);
            db.SaveChanges();
            return RedirectToAction("SendSms", "SendSms");
        }
    }
}