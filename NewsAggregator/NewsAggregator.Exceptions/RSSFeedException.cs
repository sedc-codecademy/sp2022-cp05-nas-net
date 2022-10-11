<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Exceptions
{
    public class RSSFeedException : Exception
    {
        public int? RSSFeedId { get; set; }
        public int StatusCode { get; set; }
        public RSSFeedException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public RSSFeedException(int statusCode, int? rssFeedId, string message) : base(message)
        {
            RSSFeedId = rssFeedId;
            StatusCode = statusCode;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Exceptions
{
    public class RSSFeedException : Exception
    {
        public int? RSSFeedId { get; set; }
        public int StatusCode { get; set; }
        public RSSFeedException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public RSSFeedException(int statusCode, int? rssFeedId, string message) : base(message)
        {
            RSSFeedId = rssFeedId;
            StatusCode = statusCode;
        }
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
