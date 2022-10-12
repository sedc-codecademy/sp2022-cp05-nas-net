using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.InterfaceModels.Models.Article
{
    public class ArticlesPaginationDto
    {
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int? Next { get; set; }
        public int? Previous { get; set; }
        public List<ArticleDto>? Articles { get; set; }

        public ArticlesPaginationDto(int itemsPerPage , int currentPage, int totalCount, List<ArticleDto>? articles)
        {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)itemsPerPage);
            Next = TotalPages > CurrentPage ? CurrentPage + 1 : null;
            Previous = CurrentPage > 1 ? CurrentPage - 1 : null;
            Articles = articles;
        }
    }
}