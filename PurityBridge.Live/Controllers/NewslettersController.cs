using PurityBridge.Live.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class NewslettersController : RenderMvcController
    {
        private string newsLetterPath;
        private string newsLetterLogsPath;

        public NewslettersController()
        {
            var appDataPath = HttpRuntime.AppDomainAppPath; //Server.MapPath("~/App_Data/Newsletters");
            newsLetterPath = Path.Combine(appDataPath, "Newsletters");
            if (!Directory.Exists(newsLetterPath))
            {
                Directory.CreateDirectory(newsLetterPath);
            }
            newsLetterLogsPath = Path.Combine(appDataPath, "Logs");
            if (!Directory.Exists(newsLetterLogsPath))
            {
                Directory.CreateDirectory(newsLetterLogsPath);
            }
        }

        public override ActionResult Index(RenderModel model)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName
            });

            ViewBag.BreadCrumbs = breadcrumbs;

            var newslettersNode = umbraco.uQuery.GetNodeByUrl("/newsletters/");
            List<NewsletterSummary> _summary = new List<NewsletterSummary>();

            if (newslettersNode != null)
            {
                List<string> years = new List<string>();
                newslettersNode.ChildrenAsList.ForEach(c => {
                    years.Add(c.Name);
                    c.ChildrenAsList.ForEach(cc => years.Add(cc.Name));
                });

                var newsLetters = NewsletterUtility.GetNewsletterUtility(newsLetterLogsPath).GetNewsLetters(newsLetterPath);
                newsLetters = newsLetters.Where(l => years.Contains(l.Year.ToString()) && years.Contains(l.MonthName, StringComparer.CurrentCultureIgnoreCase) && l.IsArchived == false).ToList();

                Umbraco.Core.Models.IPublishedProperty imageProperty = null;
                _summary = newsLetters.ConvertAll<NewsletterSummary>(l =>
                {
                    imageProperty = Umbraco.TypedContent(umbraco.uQuery.GetNodeIdByUrl("/newsletters/2015/april/")).GetProperty("newsletterImage");
                    l.ImageUrl = imageProperty.HasValue ? umbraco.uQuery.GetMedia(imageProperty.Value.ToString()).getProperty("umbracoFile").Value.ToString() : "/favicon.ico";
                    return l as NewsletterSummary;
                });
            }

            ViewBag.Data = _summary;
            return base.Index(model);
        }

        public ActionResult Archive(RenderModel model, string archived)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            var crumbs = archived.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName
            });

            breadcrumbs.Add(new BreadCrumbElement()
            {
                Name = (string)model.Content.Children.FirstOrDefault(c => c.UrlName == crumbs[0]).GetProperty("heading").Value,
                Value = "/" + model.Content.UrlName + "/" + crumbs[0]
            });

            ViewBag.BreadCrumbs = breadcrumbs;

            var newsLetters = NewsletterUtility.GetNewsletterUtility(newsLetterLogsPath).GetNewsLetters(newsLetterPath);
            newsLetters = newsLetters.Where(l => l.IsArchived).ToList();

            var _summary = newsLetters.ConvertAll<NewsletterSummary>(l => l as NewsletterSummary);

            ViewBag.Data = _summary;
            return View(model);
        }

        public ActionResult Newsletter(RenderModel model)
        {
            var breadcrumbs = new List<BreadCrumbElement>();
            var args = Request.RawUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            args.Reverse();
            int year;
            NewsletterModel newsLetterModel = null;
            if (int.TryParse(args.ElementAt(1), out year))
            {
                if (year > 0)
                {
                    newsLetterModel = NewsletterUtility.GetNewsletterUtility(newsLetterLogsPath).GetNewsLetterModel(newsLetterPath, args.ElementAt(0) , year);
                }
            }
            if (model == null)
            {
                new HttpStatusCodeResult(404);
            }
            ViewBag.Data = newsLetterModel;
            return View(model);
        }
    }
}
