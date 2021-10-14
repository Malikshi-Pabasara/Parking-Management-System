using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystemApi.Models;
using ParkingManagementSystemApi.Repository;

namespace ParkingManagementSystemApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewUser([FromBody] UserModel userModel)
        {
            var id = await _userRepository.AddUserAsync(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = id, controller = "User" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel userModel, [FromRoute] int id)
        {
            await _userRepository.UpdateUserAsync(id, userModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userRepository.DeleteUserAsync(id);
            return Ok();
        }

    }
}
