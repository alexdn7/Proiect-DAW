using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs.Users;
using Proiect_DAW.Services.Users;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    public class UserController : Controller
    {
        [Route("api/users")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private IUserService _userService;

            public AuthController(IUserService userService)
            {
                _userService = userService;
            }


            [HttpPost("create-user")]
            public async Task<IActionResult> CreateTeacher(User user)
            {
                await _userService.Create(user);
                return Ok();
            }

            [HttpPost("login-user")]
            public IActionResult LoginTeacher(User user)
            {
                var response = _userService.Authentificate(user);
                if (response == null)
                {
                    return BadRequest("Username or password is invalid!");
                }
                return Ok(response);
            }
        }

    }
}
