using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Models;

namespace PurityBridge.Live
{
    public class NewsletterSummary
    {
        public NewsletterSummary()
        {

        }

        public NewsletterSummary(NewsletterSummary summary)
        {
            if (summary != null)
            {
                Year = summary.Year;
                Title = string.IsNullOrEmpty(summary.Title) ? summary.MonthName + " " + summary.Year.ToString() : summary.Title;
                MonthIndex = summary.MonthIndex;
                MonthName = summary.MonthName;
                MonthDisplayName = summary.MonthDisplayName;
            }
        }

        public int Year { get; set; }

        public string Title { get; set; }

        public string MonthDisplayName { get; set; }

        public int MonthIndex { get; set; }

        public string MonthName { get; set; }

        public bool IsArchived { get; set; }

        public string ImageUrl { get; set; }
    }

    public class NewsletterModel : NewsletterSummary
    {
        public NewsletterModel()
            : base()
        {

        }

        public NewsletterModel(NewsletterModel model)
                : base(model)
        {
            if (model != null)
            {
                CreationDate = model.CreationDate;
                Content = model.Content;
            }
        }

        public DateTime CreationDate { get; set; }

        public string Content { get; set; }

    }
}