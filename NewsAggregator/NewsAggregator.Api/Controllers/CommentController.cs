using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Comment;
using NewsAggregator.Services.Abstraction;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;
        private readonly AppSettings _appSettings;

        public CommentController(ICommentService commentService, IOptions<AppSettings> appSettings)
        {
            _commentService = commentService;
            _appSettings = appSettings.Value;
        }

        //CREATE COMMENT - authenticate user only
        [Authorize(Roles = "user")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateCommentDto model)
        {

            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var res = _commentService.Create(model, userId);
                return Ok(res);
            }
            catch (CommentException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);

            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);

            }
            catch (Exception)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }
        [Authorize(Roles = "user")]
        [HttpPut("Update/{commentId}")]
        public IActionResult Update([FromBody] UpdateCommentDto model, [FromRoute] int commentId)
        {
            try
            {
                var userId = GetAuthorizedId();
                _commentService.Update(model, commentId, userId);
                return Ok();
            }
            catch (CommentException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);

            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);

            }
            catch (Exception)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }
        [Authorize(Roles = "admin,user")]
        [HttpDelete("Delete/{commentId}")]
        public IActionResult Delete([FromRoute] int commentId)
        {
            try
            {
                var role = GetAuthorizedRole();
                if (role == "admin")
                {
                    _commentService.Delete(commentId);
                    return Ok("Comment deleted successfully.");
                }
                var userId = GetAuthorizedId();
                var comment = _commentService.GetById(commentId);
                if (comment.User.Id != userId)
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                _commentService.Delete(commentId);
                return Ok("Comment deleted successfully.");
            }
            catch (CommentException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (ArticleException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);

            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);

            }
            catch (Exception)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }

        private string GetAuthorizedRole()
        {
            return User.FindFirst(ClaimTypes.Role).Value;
        }
        private int GetAuthorizedId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                throw new UserException(userId, "Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}