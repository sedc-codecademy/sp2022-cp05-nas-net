using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.Services.Abstraction;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [AllowAnonymous]
        [HttpGet("home")]
        public IActionResult GetArticles([FromQuery] int page = 0)
        {
            return Ok(_articleService.GetArticlesHomepage(page));
        }

        [AllowAnonymous]
        [HttpGet("category")]
        public IActionResult GetArticlesByCategory([FromQuery] string category, [FromQuery] int page = 0)
        {
            return Ok(_articleService.GetArticlesByCategory(category, page));
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public IActionResult GetArticlesBySearchValue([FromQuery] string search, [FromQuery] int page = 0)
        {
            return Ok(_articleService.GetArticlesBySearchValue(search, page));
        }

        [AllowAnonymous]
        [HttpGet("articles/{id:int}")]
        public IActionResult GetArticle([FromRoute] int id)
        {
            try
            {
                return Ok(_articleService.GetArticle(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost("delete")]
        public IActionResult DeleteArticle([FromRoute] int id)
        {
            try
            {
                _articleService.DeleteArticle(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

    }
}