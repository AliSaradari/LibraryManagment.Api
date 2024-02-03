using LibraryManagment.Api.Service.Authors;
using LibraryManagment.Api.Service.Authors.Dto;
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
        [HttpDelete("delete-author/{name}")]
        public void DeleteAuthor([FromRoute]string name)
        {
            _authorService.DeleteAuthor(name);
        }

    }
}
