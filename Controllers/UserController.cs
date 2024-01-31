using LibraryManagment.Api.Dto;
using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EFDataContext _context;
        public UserController()
        {
            _context = new EFDataContext();
        }
        [HttpPost("add-user")]
        public void AddUser([FromQuery] AddUserDto userDto)
        {
            var user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                MembershipDate = DateTime.Now,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        [HttpPatch("update-book")]
        public void UpdateBook([FromQuery] string usernameForUpdate, [FromQuery] UpdateUserDto updateUserDto)
        {
            var user = _context.Users.FirstOrDefault(_ => _.Name == usernameForUpdate);
            if (updateUserDto.Name != null)
            {
                user.Name = updateUserDto.Name;
            }
            if (updateUserDto.Email != null)
            {
                user.Email = updateUserDto.Email;
            }
            _context.SaveChanges();
        }
        [HttpDelete("delete-user")]
        public void DeleteUser([FromQuery] string username)
        {
            _context.Users.Remove(_context.Users.FirstOrDefault(_ => _.Name == username));
            _context.SaveChanges();
        }
        [HttpGet("show-user")]
        public GetUserDto ShowUser([FromQuery] string username)
        {
            return _context.Users.Where(_ => _.Name == username).Select(u => new GetUserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                MembershipDate = u.MembershipDate

            }).FirstOrDefault();
        }
    }
}


