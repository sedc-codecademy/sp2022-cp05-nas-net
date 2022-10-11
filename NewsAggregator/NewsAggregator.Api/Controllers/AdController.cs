using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Ad;
using NewsAggregator.Services.Abstraction;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        // TO DO: IsAdActive  -- ADMIN ONLY

        private readonly IAdService _adService;
        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet("GetAds")]
        public IActionResult GetAllAds()
        {
            return Ok(_adService.GetAllAds());
        }

        [HttpPost("CreateAd")]
        public IActionResult CreateAd([FromBody] AdDto model)
        {
            model.UserId = GetAuthorizedId();
           _adService.CreateAd(model);
            return Ok();
        }

        [HttpPut("UpdateAd")]
        public IActionResult UpdateAd([FromBody] AdDto model) 
        {
            //TO DO
            return Ok();
        }

        [HttpDelete("DeleteAd/{id}")]
        public IActionResult DeleteAd([FromRoute] int id)
        {
            _adService.DeleteAd(id);
            return Ok();
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
