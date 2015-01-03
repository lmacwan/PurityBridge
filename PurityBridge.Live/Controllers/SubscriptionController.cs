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

            var body = "<html><body>Congratulations! " + email + " has subscribed </body></html>";
            var cc = new List<string>();
            cc.Add("lmacwan@hotmail.com");
            cc.Add("richard6495@yahoo.com");
            if (MailUtility.SendSingleMail("info@puritybridge.co.uk", cc, "subscribe@pacifico.co.uk", "Newsletter submission", body, true))
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

            var body = "<html><body>Name : " + fullName + "<br />"
                        + "Phone : " + phone + "<br />"
                        + "Email : " + email + "<br />"
                        + "Message : " + message + "<br /></body></html>";
            var cc = new List<string>();
            cc.Add("lmacwan@hotmail.com");
            cc.Add("richard6495@yahoo.com");
            if (MailUtility.SendSingleMail("info@puritybridge.co.uk", cc, "bookAppointment@pacifico.co.uk", "Make an appointment ", body, true))
            {
                success = true;
                msg = "Your request has been submitted successfully.";
            }

            return Json(new { success = success, message = msg }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ContactUs(string fullName, string email, string message)
        {
            var success = false;
            var msg = string.Empty;

            var body = "<html><body>Name : " + fullName + "<br/>"
                        + "Email : " + email + "<br />"
                        + "Message : " + message + "<br /></body></html>";
            var cc = new List<string>();
            cc.Add("lmacwan@hotmail.com");
            cc.Add("richard6495@yahoo.com");
            if (MailUtility.SendSingleMail("info@puritybridge.co.uk", cc, "enquiry@pacifico.co.uk", "Contact us enquiry", body, true))
            {
                success = true;
                msg = "Your request has been submitted successfully.";
            }
            return Json(new { success = success, message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}
