using API.Services;
using Core.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly  UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            var result = await _userServices.Register(registerRequest);
            if (!result.IsSuccessed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userServices.Login(loginRequest);
            if (!result.IsSuccessed)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
