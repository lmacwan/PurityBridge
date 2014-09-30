using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class TheTeamController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = model.Content.Name,
                Value = "/" + model.Content.UrlName
            });

            ViewBag.BreadCrumbs = breadcrumbs;
            return base.Index(model);
        }
    }
}
