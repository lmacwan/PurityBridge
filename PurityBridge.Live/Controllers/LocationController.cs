using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class LocationController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var breadcrumbs = new List<PurityBridge.Live.BreadCrumbElement>();

            var locationNode = umbraco.uQuery.GetNodesByType("Location").FirstOrDefault();
            breadcrumbs.Add(new PurityBridge.Live.BreadCrumbElement()
            {
                Name = locationNode.Name,
                Value = "/" + locationNode.UrlName
            });

            ViewBag.BreadCrumbs = breadcrumbs;
            return base.Index(model);
        }
    }
}
