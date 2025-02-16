using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Dtos;
using UserService.Domain.Models;
using UserService.Services.UserServices;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            var createdUser = await _userService.CreateUser(user);
            return Ok(createdUser);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            var updatedUser = await _userService.UpdateUser(user);
            return Ok(updatedUser);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
