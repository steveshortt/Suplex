﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palladium.Security.DaclModel
{
    public static class UtilityExtensions
    {
        public static string FormatString(this bool value, string trueString = "T", string falseString = "F")
        {
            return value ? trueString : falseString;
        }
    }
}