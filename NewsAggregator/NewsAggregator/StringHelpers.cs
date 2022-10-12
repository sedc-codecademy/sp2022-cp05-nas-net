using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Helpers
{
    public static class StringHelpers
    {
        public static string Capitalize(this string value)
        {
            return char.ToUpper(value[0]) + value[1..].ToLower();
        }
    }
}