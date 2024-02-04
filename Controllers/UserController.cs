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
        [HttpPatch("update-user/{idForUpdate}")]
        public void UpdateUser([FromRoute] int idForUpdate, [FromQuery] UpdateUserDto updateUserDto)
        {
            _userService.UpdateUser(idForUpdate, updateUserDto);
        }
        [HttpDelete("delete-user/{id}")]
        public void DeleteUser([FromRoute] int id)
        {
            _userService.DeleteUser(id);
        }
        [HttpGet("show-user")]
        public List<GetUserDto>? ShowUser([FromQuery] string? username)
        {
            return _userService.ShowUser(username);
        }
        [HttpGet("show-user-books")]
        public List<GetUserBooksDto>? ShowUserBooks([FromQuery] string? username)
        {
            return _userService.ShowUserBooks(username);
        }

    }
}


