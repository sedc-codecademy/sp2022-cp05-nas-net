using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Exceptions
{
    public class ArticleException : Exception
    {
        public int? ArticleId { get; set; }
        public int StatusCode { get; set; }
        public ArticleException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public ArticleException(int statusCode, int? articleId, string message) : base(message)
        {
            ArticleId = articleId;
            StatusCode = statusCode;
        }
    }
}
