using Microsoft.AspNetCore.Mvc;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO;

namespace TalabatSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
         _userService = userService;
        }

        [HttpGet("get/users")]
        public async Task<IActionResult> GetAllUsers()
        {
            // service.getAllUser
            return Ok();
        }

        [HttpPost("add/user")]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO, [FromQuery] List<string>? roles = null)
        {
           var result = await _userService.AddUser(userDTO,roles);
            return Ok(result);
        }

        [HttpGet("get/user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // service.getUserById
            return Ok();
        }

        [HttpPut("update/user/{id}")]
        //userDto ,id
        //automapper with identity
        public async Task<IActionResult> UpdateUser(int id)
        {
            // service.updateUser
            return Ok();
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //service.deleteuser()
            return Ok();
        }
    }
}
