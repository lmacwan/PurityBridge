using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class TreatmentController : RenderMvcController
    {
        public ActionResult Details(RenderModel model)
        {
            return View(model);
        }
    }
}
