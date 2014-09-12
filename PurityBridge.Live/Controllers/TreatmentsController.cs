using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;

namespace PurityBridge.Live
{
    public class TreatmentsController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            return base.Index(model);
        }

        public ActionResult Category(RenderModel model, string category)
        {
            ViewBag.BreadCrumbs = new PageTitleModel(category.Split('/'));
            return View(model);
        }

        public ActionResult Treatment(RenderModel model, string category)
        {
            ViewBag.BreadCrumbs = new PageTitleModel(category.Split('/'));
            return View(model);
        }
    }
}