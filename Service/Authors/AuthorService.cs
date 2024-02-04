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
        public List<GetAuthorDto> ShowAuthors()
        {
            return _context.Authors.Select(a => new GetAuthorDto()
            {
                Id = a.Id,
                Name = a.Name,
            }).ToList();
        }
        public void DeleteAuthor([FromRoute] int id)
        {
            var auhtor = _context.Authors.Remove(_context.Authors.FirstOrDefault(_ => _.Id == id));
            _context.SaveChanges();
        }
    }
}
