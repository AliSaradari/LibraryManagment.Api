using LibraryManagment.Api.Service.Users;
using LibraryManagment.Api.Service.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();

        }
        [HttpPost("add-user")]
        public void AddUser([FromBody] AddUserDto userDto)
        {
            _userService.AddUser(userDto);
        }
        [HttpPatch("update-user")]
        public void UpdateUser([FromQuery] string usernameForUpdate, [FromQuery] UpdateUserDto updateUserDto)
        {
            _userService.UpdateUser(usernameForUpdate, updateUserDto);
        }
        [HttpDelete("delete-user")]
        public void DeleteUser([FromQuery] string username)
        {
            _userService.DeleteUser(username);
        }
        [HttpGet("show-user")]
        public List<GetUserDto>? ShowUser([FromQuery] string username)
        {
            return _userService.ShowUser(username);
        }
        [HttpGet("show-user-books")]
        public List<GetUserBooksDto>? ShowUserBooks([FromQuery] string username)
        {
            return _userService.ShowUserBooks(username);
        }

    }
}


