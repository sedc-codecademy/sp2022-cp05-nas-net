using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceholderController : ControllerBase
    {
        private readonly IPlaceholderService _placeholderService;

        public PlaceholderController(IPlaceholderService placeholderService)
        {
            _placeholderService = placeholderService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var res = _placeholderService.GetAll();
            return Ok(res);
        }
    }
}
