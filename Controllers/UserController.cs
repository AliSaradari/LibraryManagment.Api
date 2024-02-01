using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Books;
using LibraryManagment.Api.Service.Users;
using LibraryManagment.Api.Service.Users.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/User")]
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
        [HttpPatch("update-book")]
        public void UpdateBook([FromBody] string usernameForUpdate, [FromQuery] UpdateUserDto updateUserDto)
        {
            _userService.UpdateBook(usernameForUpdate, updateUserDto);
        }
        [HttpDelete("delete-user")]
        public void DeleteUser([FromBody] string username)
        {
            _userService.DeleteUser(username);
        }
        [HttpGet("show-user")]
        public List<GetUserDto>? ShowUser([FromQuery] string username)
        {
            return _userService.ShowUser(username);
        }
    }
}


