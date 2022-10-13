using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Ad;
using NewsAggregator.Services.Abstraction;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        // TO DO: IsAdActive  -- ADMIN ONLY

        private readonly IAdService _adService;
        private readonly AppSettings _appSettings;
        public AdController(IAdService adService, IOptions<AppSettings> appSettings)
        {
            _adService = adService;
            _appSettings = appSettings.Value;
        }

        [HttpGet("GetAds")]
        public IActionResult GetAllAds()
        {
            try
            {
                var res = _adService.GetAllAds();
                return Ok(res);
            }
            catch (AdException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetActiveAds")]
        public IActionResult GetActiveAds()
        {
            try
            {
                var res = _adService.GetActiveAds();
                return Ok(res);
            }
            catch (AdException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpPost("CreateAd")]
        public IActionResult CreateAd([FromBody] CreateAdDto model)
        {
            try
            {
                var res = _adService.CreateAd(model);
                return Ok(res);
            }
            catch (AdException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpPut("Toggle/id/{adId}")]
        public IActionResult ToggleActiveAd([FromRoute] int adId)
        {
            try
            {
                var active = _adService.Toggle(adId);
                return Ok($"Ad {(active ? "enabled" : "disabled")}.");
            }
            catch (AdException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpPut("UpdateAd/id/{adId}")]
        public IActionResult UpdateAd([FromBody] UpdateAdDto model, [FromRoute] int adId)
        {
            try
            {
                _adService.UpdateAd(model, adId);
                return Ok("Ad updated successfully.");
            }
            catch (AdException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpDelete("DeleteAd/{id}")]
        public IActionResult DeleteAd([FromRoute] int id)
        {
            try
            {
                _adService.DeleteAd(id);
                return Ok($"Ad with Id:{id} deleted successfully.");
            }
            catch (AdException aex)
            {
                return StatusCode(aex.StatusCode, aex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }
    }
}
