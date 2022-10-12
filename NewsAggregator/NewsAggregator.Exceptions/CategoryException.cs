
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Exceptions
{
    public class CategoryException : Exception
    {
        public int? CategoryId { get; set; }
        public int StatusCode { get; set; }
        public CategoryException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public CategoryException(int statusCode, int? categoryId, string message) : base(message)
        {
            CategoryId = categoryId;
            StatusCode = statusCode;
        }
    }
}
