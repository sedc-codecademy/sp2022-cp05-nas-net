using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.Services.Abstraction;
using NewsAggregator.Services.Implementation;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _articleService = articleService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetArticles([FromQuery] int page = 1)
        {
            try
            {
                var res = _articleService.GetArticles(page);
                return Ok(res);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }

        [HttpGet("GetByCategory")]
        public IActionResult GetArticlesByCategory([FromQuery] int categoryId, [FromQuery] int page = 1)
        {
            try
            {
                var res = _articleService.GetArticlesByCategory(categoryId, page);
                return Ok(res);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }

        [HttpGet("Search")]
        public IActionResult GetArticlesBySearchValue([FromQuery] string search, [FromQuery] int page = 1)
        {
            try
            {
                var res = _articleService.GetArticlesBySearchValue(search, page);
                return Ok(res);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetArticle([FromRoute] int id)
        {
            try
            {
                var res = _articleService.GetArticle(id);
                return Ok(res);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteArticle([FromRoute] int id)
        {
            try
            {
                _articleService.DeleteArticle(id);
                return Ok("Article deleted successfully");
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }
    }
}
