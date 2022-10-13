using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Exceptions
{
    public class AdException : Exception
    {
        public int? AdId { get; set; }
        public int StatusCode { get; set; }
        public AdException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public AdException(int statusCode, int? adId, string message) : base(message)
        {
            AdId = adId;
            StatusCode = statusCode;
        }
    }
}
