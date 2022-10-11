using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Services.Abstraction;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Authorize(Roles = "user")]
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
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CommentDto model, [FromRoute] int articleId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                _commentService.Create(model, userId, articleId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not create comment.");
            }
        }

        //UPDATE COMMENT - authenticate and authorize comment owner
        [HttpPut("Update/{id:int}")]
        public IActionResult Update([FromBody] CommentDto model, [FromRoute] int commentId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                _commentService.Update(model, commentId, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not update comment.");
            }
        }

        //DELETE COMMENT - authenticate and authorize comment owner
    }
}
