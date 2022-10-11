<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
