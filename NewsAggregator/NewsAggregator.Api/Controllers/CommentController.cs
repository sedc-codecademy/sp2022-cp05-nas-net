using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Exceptions;
using NewsAggregator.Services.Abstraction;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Authorize]
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

        //UPDATE COMMENT - authenticate and authorize comment owner

        //DELETE COMMENT - authenticate and authorize comment owner


    }
}
