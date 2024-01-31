using LibraryManagment.Api.Dto;
using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly EFDataContext _context;
        public BookController()
        {
            _context = new EFDataContext();
        }
        [HttpPost("add-book")]
        public void AddBook([FromQuery] AddBookDto bookDto)
        {
            var book = new Book()
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                PublishYear = bookDto.PublishYear
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        [HttpPatch("update-book")]
        public void UpdateBook([FromQuery] string titleForUpdate, [FromQuery] UpdateBookDto updateBookDto)
        {
            var book = _context.Books.FirstOrDefault(_ => _.Title == titleForUpdate);
            if (updateBookDto.Genre != null)
            {
                book.Genre = updateBookDto.Genre;
            }
            if (updateBookDto.PublishYear != null)
            {
                book.PublishYear = updateBookDto.PublishYear;
            }
            if (updateBookDto.Author != null)
            {
                book.Author = updateBookDto.Author;
            }
            _context.SaveChanges();
        }
        [HttpDelete("delete-book")]
        public void DeleteBook([FromQuery] string title)
        {
            _context.Books.Remove(_context.Books.FirstOrDefault(_ => _.Title == title));
            _context.SaveChanges();
        }
        [HttpGet("show-books")]
        public GetBookDto ShowBooks([FromQuery] string? title, [FromQuery] string? genre)
        {
            if(title != null)
            {
                var book = _context.Books.FirstOrDefault(_ => _.Title == title);
                var dto = new GetBookDto()
                {
                    Title = book.Title,
                    Genre = book.Genre,
                    Author = book.Author,
                    PublishYear = book.PublishYear,
                };
                return dto;
            }
            else
            {
                var book = _context.Books.FirstOrDefault(_ => _.Genre == genre);
                var dto = new GetBookDto()
                {
                    Title = book.Title,
                    Genre = book.Genre,
                    Author = book.Author,
                    PublishYear = book.PublishYear,
                };
                return dto;
            }
            
            





        }
    }
}


