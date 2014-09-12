using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurityBridge.Live
{
    public class PageTitleModel
    {
        public PageTitleModel(params string[] args)
        {
            BreadCrumbs = new List<string>();
            if (args != null)
            {
                foreach (var arg in args)
                {
                    if (!(string.IsNullOrEmpty(arg)))
                    {
                        BreadCrumbs.Add(arg);
                    }
                }
            }
        }
        public List<string> BreadCrumbs { get; private set; }
    }
}