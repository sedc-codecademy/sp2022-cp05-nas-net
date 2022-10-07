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
        [HttpGet("articles")]
        public ActionResult<IEnumerable<ArticleDto>> GetArticles()
        {
            return Ok(_articleService.GetArticles());
        } // TODO - Backend pagination logic

        [AllowAnonymous]
        [HttpGet("articles/{id:int}")]
        public ActionResult<ArticleDto> GetArticle([FromRoute] int id)
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
        public ActionResult DeleteArticle([FromRoute] int id)
        {
            try
            {
                _articleService.DeleteArticle(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize(Roles = "user")]
        [HttpPost("comment")]
        public ActionResult<CommentDto> AddComment([FromBody] AddCommentDto dto, int articleId)
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                return Ok(_articleService.AddComment(dto, id, articleId));
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "user,admin")]
        [HttpGet("user-comments")]
        public ActionResult<IEnumerable<CommentDto>> GetUserComments(int userIdByAdmin = 0)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var id = User.FindFirstValue(ClaimTypes.Role) == "user" ? userId : userIdByAdmin;

            try
            {
                return Ok(_articleService.GetUserComments(id));
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize(Roles = "user,admin")]
        [HttpPost("delete-comment")]
        public ActionResult DeleteComment(int commentId)
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                _articleService.DeleteComment(commentId, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}