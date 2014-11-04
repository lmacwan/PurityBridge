using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbraco;
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
                Name = uQuery.GetNodesByType("Gallery").First().GetProperty<string>("heading"),
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
                Name = uQuery.GetNodesByType("Gallery").First().GetProperty<string>("heading"),
                Value = "/gallery"
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = model.Content.Name,
                Value = "/gallery/" + model.Content.UrlName
            });

            var name = crumbs[0] == "treatments"
                        ? (string)umbraco.uQuery.GetNodesByType("Treatments").FirstOrDefault().GetProperty("heading").Value
                        : (string)umbraco.uQuery.GetNodesByType("video").FirstOrDefault(c => c.UrlName == crumbs[0]).GetProperty("heading").Value;
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = name,
                Value = "/gallery/" + model.Content.UrlName + "/" + crumbs[0]
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
                Name = uQuery.GetNodesByType("Gallery").First().GetProperty<string>("heading"),
                Value = "/gallery"
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/gallery/" + model.Content.UrlName
            });

            var name = crumbs[0] == "treatments"
            ? (string)umbraco.uQuery.GetNodesByType("Treatments").FirstOrDefault().GetProperty("heading").Value
            : (string)umbraco.uQuery.GetNodesByType("video").FirstOrDefault(c => c.UrlName == crumbs[0]).GetProperty("heading").Value;
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = name,
                Value = "/gallery/"+ model.Content.UrlName + "/" + crumbs[0]
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)uQuery.GetNodesByType("Treatment").FirstOrDefault(n =>n.UrlName == crumbs[1]).GetProperty("heading").Value,
                Value = "/gallery/"
            });

            ViewBag.BreadCrumbs = breadcrumbs;
            return View(model);
        }
    }
}
