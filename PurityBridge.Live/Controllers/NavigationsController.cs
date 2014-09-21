using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class NavigationsController : RenderMvcController
    {
        public ActionResult Category(RenderModel model)
        {
            return View(model);
        }
    }
}
