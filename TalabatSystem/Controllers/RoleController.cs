using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TalabatSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register()  //RegisterDTO
        {
            //service.register
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login() // LoginDTO
        {
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()  // clear refresh token
        {
            return Ok();
        }
    }
}
