using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Category;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ICategoryService _categoryService;

        public CategoryController(IOptions<AppSettings> appSettings, ICategoryService categoryService)
        {
            _appSettings = appSettings.Value;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _categoryService.GetAll();
                return Ok(res);
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
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateCategoryDto model)
        {
            try
            {
                var res = _categoryService.Create(model);
                return Ok(res);
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
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateCategoryDto model)
        {
            try
            {
                _categoryService.Update(model, id);
                return Ok("Category updated successfully.");
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
                _categoryService.Delete(id);
                return Ok("Category deleted successfully.");
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
