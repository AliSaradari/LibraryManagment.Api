using LibraryManagment.Api.Service.Books;
using LibraryManagment.Api.Service.Books.Dto;
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
        [HttpPatch("update-book/{titleForUpdate}")]
        public void UpdateBook([FromQuery] string titleForUpdate, [FromQuery] UpdateBookDto updateBookDto)
        {
            _bookService.UpdateBook(titleForUpdate, updateBookDto);
        }
        [HttpDelete("delete-book/{title}")]
        public void DeleteBook([FromRoute] string title)
        {
            _bookService?.DeleteBook(title);
        }
        [HttpGet("show-books")]
        public List<GetBookDto?> ShowBooks([FromQuery] string? title, [FromQuery] string? genre)
        {
            return
            _bookService.ShowBooks(title, genre);
        }
        [HttpPost("rent-book")]
        public void RentBook([FromBody] RentBookDto dto)
        {
            _bookService.RentBook(dto);
        }
        [HttpPatch("return-book")]
        public void ReturnBook([FromBody] ReturnBookDto dto)
        {
            _bookService.ReturnBook(dto);
        }
    }
}


