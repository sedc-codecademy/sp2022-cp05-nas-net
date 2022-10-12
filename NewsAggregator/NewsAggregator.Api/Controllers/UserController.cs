using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAggregator.Configurations;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.User;
using NewsAggregator.Services.Abstraction;
using System.Security.Claims;

namespace NewsAggregator.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public UserController(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateUserDto model)
        {
            try
            {
                var user = _userService.Authenticate(model.LoginProvider, model.Password);
                return Ok(user);
            }
            catch (UserException ue)
            {
                return StatusCode(ue.StatusCode, ue.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterUserDto model)
        {
            try
            {
                _userService.Register(model);
                return Ok("Registred successfully.");
            }
            catch (UserException ue)
            {
                return StatusCode(ue.StatusCode, ue.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("Update/id/{userId}")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto model, [FromRoute] int userId)
        {
            try
            {
                var authorizedUserId = GetAuthorizedId();

                if (userId != authorizedUserId)
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                _userService.Update(model, userId);
                return Ok("User updated");
            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);

            }
            catch (Exception)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);

            }
        }

        [HttpPut("ChangePassword/id/{userId}")]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto model, [FromRoute] int userId)
        {
            try
            {
                var authorizedUserId = GetAuthorizedId();

                if (userId != authorizedUserId)
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                _userService.ChangePassword(model, userId);
                return Ok("Password Changed");
            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);

            }
            catch (Exception)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);

            }
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                var role = GetAuthorizedRole();
                if (role != "admin")
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (UserException ue)
            {
                return StatusCode(ue.StatusCode, ue.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("GetById/id/{userId}")]
        public IActionResult GetById([FromRoute] int userId)
        {
            try
            {
                var role = GetAuthorizedRole();
                if (role != "admin")
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                var user = _userService.GetById(userId);
                return Ok(user);
            }
            catch (UserException ue)
            {
                return StatusCode(ue.StatusCode, ue.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("RegisterAdmin")]
        public IActionResult RegisterAdmin([FromBody] RegisterUserDto model)
        {
            try
            {
                var role = GetAuthorizedRole();
                if (role != "admin")
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                _userService.RegisterAdmin(model);
                return Ok("Admin registered successfully.");
            }
            catch (UserException ue)
            {
                return StatusCode(ue.StatusCode, ue.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("Delete/id/{userId}")]
        public IActionResult Delete([FromRoute] int userId)
        {
            try
            {
                var role = GetAuthorizedRole();
                var authenticatedUserId = GetAuthorizedId();
                if (role != "admin")
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                if (authenticatedUserId == userId)
                {
                    throw new UserException(400, "Cannot delete self.");

                }
                _userService.Delete(userId);
                return Ok("User deleted successfully");
            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
