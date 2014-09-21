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

        public ActionResult TreatmentVideos(RenderModel model, string category)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            var crumbs = category.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

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

            var name = crumbs[0] == "treatments" 
                        ? umbraco.uQuery.GetNodesByType("TreatmentsData").FirstOrDefault().Name 
                        : umbraco.uQuery.GetNodesByType("video").FirstOrDefault(c => c.UrlName == crumbs[0]).Name;
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = name,
                Value = "/gallery" + model.Content.UrlName + "/" + crumbs[0]
            });
            ViewBag.BreadCrumbs = breadcrumbs;
            return View(model);
        }

        public ActionResult Videos(RenderModel model, string category)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            var crumbs = category.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

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
            return View(model);
        }
    }
}
