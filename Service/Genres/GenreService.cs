using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Genres.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Service.Genres
{
    public class GenreService
    {
        EFDataContext _context = new EFDataContext();

        public void AddGenre([FromBody]AddGenreDto dto)
        {
            var genre = new Genre() {Name = dto.Name };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        public void DeleteGenre([FromRoute]string name)
        {
            var genre = _context.Genres.Remove(_context.Genres.FirstOrDefault(_ => _.Name == name));
            _context.SaveChanges();
        }
    }
}
