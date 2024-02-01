using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Books.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Service.Books
{
    public class BookService
    {
        EFDataContext _context = new EFDataContext();
        public void AddBook([FromBody] AddBookDto bookDto)
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
        public void UpdateBook([FromBody] string titleForUpdate, [FromBody] UpdateBookDto updateBookDto)
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
        public void DeleteBook([FromBody] string title)
        {
            _context.Books.Remove(_context.Books.FirstOrDefault(_ => _.Title == title));
            _context.SaveChanges();
        }
        public List<GetBookDto> ShowBooks([FromQuery] string? title, [FromQuery] string genre)
        {
            if (title != null)
            {
                var book = _context.Books.Where(_ => _.Title == title).Select(b => new GetBookDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    Author = b.Author,
                    PublishYear = b.PublishYear
                }).ToList();
                return book;
            }
            else
            {
                var book = _context.Books.Where(_ => _.Genre == genre).Select(b => new GetBookDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    Author = b.Author,
                    PublishYear = b.PublishYear
                }).ToList();
                return book;
            }
        }
    }
}

