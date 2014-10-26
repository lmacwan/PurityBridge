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
            var breadcrumbs = new List<BreadCrumbElement>();
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName
            });

            ViewBag.BreadCrumbs = breadcrumbs;
            return base.Index(model);
        }

        public ActionResult Category(RenderModel model, string category)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            var crumbs = category.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.Children.FirstOrDefault(c => c.UrlName == crumbs[0]).GetProperty("heading").Value,
                Value = "/treatments/" + crumbs[0]
            });
            ViewBag.BreadCrumbs = breadcrumbs;
            return View(model);
        }

        public ActionResult Treatment(RenderModel model, string category)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            var crumbs = category.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.Children.FirstOrDefault(c => c.UrlName == crumbs[0]).GetProperty("heading").Value,
                Value = "/treatments/" + crumbs[0]
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = umbraco.uQuery.GetNodesByType("TreatmentData").Where(c => c.UrlName == crumbs[1]).FirstOrDefault(t => t.Parent.Parent.NodeTypeAlias == "TreatmentsData").Name,
                Value = "/treatments/" + crumbs[0] + "/" + crumbs[1]
            });
            ViewBag.BreadCrumbs = breadcrumbs;
            return View(model);
        }
    }
}