using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RSSFeedController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IRSSFeedService _rssService;

        public RSSFeedController(IRSSFeedService rssService, IOptions<AppSettings> appSettings)
        {
            _rssService = rssService;
            _appSettings = appSettings.Value;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _rssService.GetAll();
                return Ok(res);
            }
            catch (RSSFeedException rex)
            {
                return StatusCode(rex.StatusCode, rex.Message);
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

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateRSSFeedDto model)
        {
            try
            {
                var res = _rssService.Create(model);
                return Ok(res);
            }
            catch (RSSFeedException rex)
            {
                return StatusCode(rex.StatusCode, rex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (CategoryException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpPut("Toggle/id/{id}")]
        public IActionResult Toggle([FromRoute] int id)
        {
            try
            {
                var active = _rssService.Toggle(id);
                return Ok($"Rss feed {(active ? "enabled" : "disabled")}.");
            }
            catch (RSSFeedException rex)
            {
                return StatusCode(rex.StatusCode, rex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (CategoryException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpPut("Update/id/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRSSDto model)
        {
            try
            {
                _rssService.Update(model, id);
                return Ok("Rss feed updated successfully.");
            }
            catch (RSSFeedException rex)
            {
                return StatusCode(rex.StatusCode, rex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (CategoryException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }

        [HttpDelete("Delete/id/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _rssService.Delete(id);
                return Ok("Rss feed deleted successfully.");
            }
            catch (RSSFeedException rex)
            {
                return StatusCode(rex.StatusCode, rex.Message);
            }
            catch (UserException uex)
            {
                return StatusCode(uex.StatusCode, uex.Message);
            }
            catch (CategoryException cex)
            {
                return StatusCode(cex.StatusCode, cex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, _appSettings.DefaultErrorMessage);
            }
        }
    }
}
