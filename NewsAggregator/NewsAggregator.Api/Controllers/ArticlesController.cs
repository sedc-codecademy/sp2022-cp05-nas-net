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
        
        //TODO : 

        //GET BY CATEGORY

        //GET BY SEARCH RESULT


        [AllowAnonymous]
        [HttpGet("articles")]
        public IActionResult GetArticles()
        {
            return Ok(_articleService.GetArticles());
        } // TODO - Backend pagination logic

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