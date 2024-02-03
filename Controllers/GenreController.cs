using LibraryManagment.Api.Service.Genres;
using LibraryManagment.Api.Service.Genres.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;
        public GenreController()
        {
            _genreService = new GenreService();
        }
        [HttpPost("add-genre")]
        public void AddGenre([FromBody] AddGenreDto dto)
        {
            _genreService.AddGenre(dto);
        }
        [HttpDelete("delete-genre/{name}")]
        public void DeleteGenre([FromRoute]string name)
        {
            _genreService.DeleteGenre(name);
        }
    }
}
