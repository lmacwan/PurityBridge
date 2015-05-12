using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurityBridge.Live
{
    public enum Month
    {
        [Month(1, "January", shortName="Jan")]
        JANUARY = 1,
        [Month(2, "February", shortName = "Feb")]
        FEBRUARY = 2,
        [Month(3, "March", shortName = "Mar")]
        MARCH = 3,
        [Month(4, "April", shortName = "Apr")]
        APRIL = 4,
        [Month(5, "May", shortName = "May")]
        MAY = 5,
        [Month(6, "June", shortName = "Jun")]
        JUNE = 6,
        [Month(7, "Jul", shortName = "Jul")]
        JULY = 7,
        [Month(8, "August", shortName = "Aug")]
        AUGUST = 8,
        [Month(9, "September", shortName = "Sep")]
        SEPTEMBER = 9,
        [Month(10, "October", shortName = "Oct")]
        OCTOBER = 10,
        [Month(11, "November", shortName = "Nov")]
        NOVEMBER = 11,
        [Month(12, "December", shortName = "Dec")]
        DECEMBER = 12,
        [Month(-1, "All")]
        ALL = 0
    }
}