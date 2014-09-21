﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class PhotosController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var breadcrumbs = new List<BreadCrumbElement>();

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = "Gallery",
                Value = "/gallery"
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = model.Content.Name,
                Value = "/gallery/" + model.Content.UrlName
            });
            ViewBag.BreadCrumbs = breadcrumbs;
            return base.Index(model);
        }

        public ActionResult Treatment(RenderModel model)
        {
            var breadcrumbs = new List<BreadCrumbElement>();

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = "Gallery",
                Value = "/gallery"
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = model.Content.Name,
                Value = "/gallery/" + model.Content.UrlName
            });

            var crumb = Request.RawUrl.Split(new string[]{"/"}, StringSplitOptions.RemoveEmptyEntries).Last();

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = umbraco.uQuery.GetNodesByType("Treatment").Where(c => c.UrlName == crumb).FirstOrDefault(t => t.Parent.Parent.NodeTypeAlias == "TreatmentsData").Name,
                Value = "/" + model.Content.UrlName + "/" + crumb
            });
            ViewBag.BreadCrumbs = breadcrumbs;
            return View(model);
        }

        public ActionResult Get(int id)
        {
            return PartialView("GetPhoto", Umbraco.TypedContent(id));
        }
    }
}
