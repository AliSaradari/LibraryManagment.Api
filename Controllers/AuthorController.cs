using LibraryManagment.Api.Service.Authors;
using LibraryManagment.Api.Service.Authors.Dto;
using LibraryManagment.Api.Service.Genres.Dto;
using LibraryManagment.Api.Service.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        [HttpPost("add-author")]
        public void AddAuthor([FromBody] AddAuthorDto dto)
        {
            _authorService.AddAuthor(dto);
        }
        [HttpGet("show-authors")]
        public List<GetAuthorDto> ShowAuthors()
        {
            return _authorService.ShowAuthors();
        }
        [HttpDelete("delete-author/{id}")]
        public void DeleteAuthor([FromRoute] int id)
        {
            _authorService.DeleteAuthor(id);
        }

    }
}
