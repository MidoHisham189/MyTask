using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tekegy_SendSms_Task.Controllers
{
    public class SendSmsController : Controller
    {
        // GET: SendSms
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult SendSms()
        {

            return View();
        }

      
    }
}