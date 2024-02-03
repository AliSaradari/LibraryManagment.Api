﻿using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Users.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Service.Users
{
    public class UserService
    {
        EFDataContext _context = new EFDataContext();
        public void AddUser([FromBody] AddUserDto userDto)
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
        public void UpdateUser([FromQuery] string usernameForUpdate, [FromQuery] UpdateUserDto updateUserDto)
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
        public void DeleteUser([FromQuery] string username)
        {
            _context.Users.Remove(_context.Users.FirstOrDefault(_ => _.Name == username));
            _context.SaveChanges();
        }
        public List<GetUserDto>? ShowUser([FromQuery] string username)
        {
            return _context.Users.Where(_ => _.Name == username).Select(u => new GetUserDto
            {
                Name = u.Name,
                Email = u.Email,
                MembershipDate = u.MembershipDate

            }).ToList();
        }
        //Fix The problem of showing the names of duplicate books
        public List<GetUserBooksDto>? ShowUserBooks([FromQuery] string username)
        {
            var userId = _context.Users.FirstOrDefault(_ => _.Name == username).Id;
            return _context.RentedBooks.Where(_ => _.UserId == userId).Select(b => new GetUserBooksDto
            {
                Title = _context.Books.FirstOrDefault(_ => _.Id == b.Id).Title,
                Condition = b.Condition
            }).ToList();
        }
    }
}
