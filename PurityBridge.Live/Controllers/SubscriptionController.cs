using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurityBridge.Live
{
    public class SubscriptionController : Umbraco.Web.Mvc.SurfaceController
    {
        public JsonResult SubscribeNewsletter(string email)
        {
            var success = false;
            var msg = string.Empty;

            if (MailUtility.SendSingleMail(email))
            {
                success = true;
                msg = "Your request has been submitted successfully.";
            }

            return Json(new { success = success, message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}
