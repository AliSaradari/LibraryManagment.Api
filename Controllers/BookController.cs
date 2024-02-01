using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Books;
using LibraryManagment.Api.Service.Books.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        [HttpPost("add-book")]
        public void AddBook([FromBody] AddBookDto bookDto)
        {
            _bookService.AddBook(bookDto);
        }
        [HttpPatch("update-book")]
        public void UpdateBook([FromBody] string titleForUpdate, [FromQuery] UpdateBookDto updateBookDto)
        {
            _bookService.UpdateBook(titleForUpdate, updateBookDto);
        }
        [HttpDelete("delete-book")]
        public void DeleteBook([FromBody] string title)
        {
            _bookService?.DeleteBook(title);
        }
        [HttpGet("show-books")]
        public List<GetBookDto?> ShowBooks([FromQuery] string? title, [FromQuery] string? genre)
        {
            return
            _bookService.ShowBooks(title, genre);
        }
    }
}


