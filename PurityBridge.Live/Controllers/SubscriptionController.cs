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

        public JsonResult BookAppointment(string fullName, string phone, string email, string message)
        {
            var success = false;
            var msg = string.Empty;

            var body = "Name : " + fullName + "\n"
                        + "Phone : " + phone + "\n"
                        + "Email : " + email + "\n"
                        + "Message : " + message;
            var cc = new List<string>();
            cc.Add("richard6495@yahoo.com");
            if (MailUtility.SendSingleMail("lmacwan@hotmail.com", cc, "enquiry@pacifico.co.uk", "Appointment Enquiry", body, true))
            {
                success = true;
                msg = "Your request has been submitted successfully.";
            }

            return Json(new { success = success, message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}
