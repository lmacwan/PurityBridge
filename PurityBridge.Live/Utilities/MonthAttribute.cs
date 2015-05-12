using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurityBridge.Live
{
    public class MonthAttribute : Attribute
    {
        int index;
        string name;
        public string shortName;

        public MonthAttribute(int index, string name)
        {
            this.name = name;
            this.index = index;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetIndex()
        {
            return this.index;
        }

        public string GetShortName()
        {
            return string.IsNullOrEmpty(this.shortName) ? this.name : this.shortName;
        }
    }
}