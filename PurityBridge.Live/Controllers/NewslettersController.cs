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
            newsLetterLogsPath = Path.Combine(newsLetterPath, "Logs");
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

            var newsLetters = NewsletterUtility.GetNewsletterUtility(newsLetterLogsPath).GetNewsLetters(newsLetterPath);
            newsLetters = newsLetters.Where(l => l.IsArchived == false).ToList();

            var _summary = newsLetters.ConvertAll<NewsletterSummary>(l => l as NewsletterSummary);

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
            var args = Request.RawUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            int year;
            int month;
            NewsletterModel newsLetterModel = null;
            if (int.TryParse(args.Length >= 1 ? args[0] : "-1", out year) && int.TryParse(args.Length >= 2 ? args[1] : "-1", out  month))
            {
                if (year > 0 && month > 0)
                {
                    newsLetterModel = NewsletterUtility.GetNewsletterUtility(newsLetterLogsPath).GetNewsLetterModel(newsLetterPath, month, year);
                }
            }
            if (model == null)
            {
                new HttpStatusCodeResult(404);
            }
            return View(model);
        }
    }
}
