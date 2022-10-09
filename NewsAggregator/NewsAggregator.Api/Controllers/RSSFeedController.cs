using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RSSFeedController : ControllerBase
    {

        private readonly IRSSFeedService _rssService;

        public RSSFeedController(IRSSFeedService rssService)
        {
            _rssService = rssService;
        }

        [HttpGet("/GetAll")]
        public IActionResult GetAll()
        {
            var res = _rssService.GetAll();
            return Ok(res);
        }

        [HttpPost("/Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("/update/id/{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            return Ok(id);
        }

        [HttpDelete("/delete/id/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok();
        }
    }
}
