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
            Year = summary.Year;
            Month = summary.Month;
            Title = summary.Title;
        }

        public int Year { get; set; }

        public Month Month { get; set; }

        public string Title { get; set; }
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