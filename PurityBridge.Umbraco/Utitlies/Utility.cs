using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurityBridge.Umbraco
{
    public class Utility
    {
        public static int GetSpanEquivalent(string span)
        {
           var cols = span.Contains("Less")
                        ? 3
                        : span.Contains("More")
                            ? 9
                            : span.Contains("Full")
                                ? 12
                                : 6;
           return cols;
        }
    }
}