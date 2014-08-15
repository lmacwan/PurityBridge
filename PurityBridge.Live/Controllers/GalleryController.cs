using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live.Controllers
{
    public class GalleryController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            return base.Index(model);
        }

        //public ActionResult Treatment(RenderModel model)
        //{
        //    return View(model);
        //}
    }
}
