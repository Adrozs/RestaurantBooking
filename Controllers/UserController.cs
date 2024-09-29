using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Models.DTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("AdminLogin")]
        public async Task<IActionResult> AdminLoginAsync(UserCredsDto userCredsDto)
        {
            try
            {
                string jwt = await _userService.LoginAsync(userCredsDto);
                if (jwt.IsNullOrEmpty())
                    return BadRequest("An unexpected error occurred while trying to login.");

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdminAsync(UserCredsDto userCredsDto)
        {
            try
            {
                bool result = await _userService.CreateAccountAsync(userCredsDto);
                if (!result)
                    return BadRequest("An unexpected error occurred while trying to create the account.");

                return Ok("Successfully created account.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
