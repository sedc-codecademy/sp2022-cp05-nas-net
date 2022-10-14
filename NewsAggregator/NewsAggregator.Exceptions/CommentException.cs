using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Exceptions
{
    public class CommentException : Exception
    {
        public int? CommentId { get; set; }
        public int StatusCode { get; set; }
        public CommentException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public CommentException(int statusCode, int? commentId, string message) : base(message)
        {
            CommentId = commentId;
            StatusCode = statusCode;
        }
    }
}