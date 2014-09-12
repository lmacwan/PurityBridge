using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class VideosController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            return base.Index(model);
        }

        public ActionResult TreatmentVideos(RenderModel model, string category)
        {
            ViewBag.BreadCrumbs = new PageTitleModel(category.Split('/'));
            return View(model);
        }

        public ActionResult Videos(RenderModel model, string category)
        {
            ViewBag.BreadCrumbs = new PageTitleModel(category.Split('/'));
            return View(model);
        }
    }
}
