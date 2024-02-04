using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Genres.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Service.Genres
{
    public class GenreService
    {
        EFDataContext _context = new EFDataContext();

        public void AddGenre([FromBody] AddGenreDto dto)
        {
            var genre = new Genre() { Name = dto.Name };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        public List<GetGenreDto> ShowGenres()
        {
            return _context.Genres.Select(g => new GetGenreDto()
            {
                Id = g.Id,
                Name = g.Name,
            }).ToList();
        }
        public void DeleteGenre([FromRoute] int id)
        {
            var genre = _context.Genres.Remove(_context.Genres.FirstOrDefault(_ => _.Id == id));
            _context.SaveChanges();
        }
    }
}
