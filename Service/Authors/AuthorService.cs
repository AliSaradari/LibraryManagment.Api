using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Authors.Dto;
using LibraryManagment.Api.Service.Genres.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Service.Authors
{
    public class AuthorService
    {
        EFDataContext _context = new EFDataContext();
        public void AddAuthor([FromBody] AddAuthorDto dto)
        {
            var author = new Author() { Name = dto.Name };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void DeleteAuthor([FromRoute] string name)
        {
            var auhtor = _context.Authors.Remove(_context.Authors.FirstOrDefault(_ => _.Name == name));
            _context.SaveChanges();
        }
    }
}
