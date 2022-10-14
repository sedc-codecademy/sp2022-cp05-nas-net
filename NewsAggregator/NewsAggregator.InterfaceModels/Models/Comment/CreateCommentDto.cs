using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.InterfaceModels.Models.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}
