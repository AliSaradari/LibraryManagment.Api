using LibraryManagment.Api.EntitiyMaps;
using LibraryManagment.Api.Service.Books.Dto;
using LibraryManagment.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Api.Service.Books
{
    public class BookService
    {
        EFDataContext _context = new EFDataContext();

        public void AddBook([FromBody] AddBookDto bookDto)
        {
            var authorExist = _context.Authors.Any(_ => _.Name == bookDto.Author);
            if (authorExist == false)
            {
                var author = new Author { Name = bookDto.Author };
                _context.Authors.Add(author);
                _context.SaveChanges();
            }
            var genreExist = _context.Genres.Any(_ => _.Name == bookDto.Genre);
            if (genreExist == false)
            {
                var genre = new Genre { Name = bookDto.Genre };
                _context.Genres.Add(genre);
                _context.SaveChanges();
            }
            var bookAuthor = _context.Authors.FirstOrDefault(_ => _.Name == bookDto.Author);
            var bookGenre = _context.Genres.FirstOrDefault(_ => _.Name == bookDto.Genre);
            var book = new Book()
            {
                Title = bookDto.Title,
                AuthorId = bookAuthor.Id,
                GenreId = bookGenre.Id,
                PublishYear = bookDto.PublishYear,
                Count = bookDto.Count,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook([FromRoute] int idForUpdate, [FromQuery] UpdateBookDto updateBookDto)
        {
            var book = _context.Books.FirstOrDefault(_ => _.Id == idForUpdate);

            if (updateBookDto.Genre != null)
            {
                var newGenre = _context.Genres.FirstOrDefault(_ => _.Name == updateBookDto.Genre);
                book.GenreId = newGenre.Id;
            }
            if (updateBookDto.PublishYear != null)
            {
                book.PublishYear = updateBookDto.PublishYear;
            }
            if (updateBookDto.Author != null)
            {
                var newAuthor = _context.Authors.FirstOrDefault(_ => _.Name == updateBookDto.Author);
                book.AuthorId = newAuthor.Id;
            }
            if (updateBookDto.Count != null)
            {
                book.Count = (int)updateBookDto.Count;
            }
            _context.SaveChanges();
        }
        public void DeleteBook([FromRoute] int id)
        {   
            _context.Books.Remove(_context.Books.FirstOrDefault(_ => _.Id == id));
            _context.SaveChanges();
        }
        public List<GetBookDto> ShowBooks([FromQuery] string? title, [FromQuery] string genre)
        {

            if (title != null)
            {
                var book = _context.Books.Where(_ => _.Title == title).Select(b => new GetBookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = _context.Genres.FirstOrDefault(_ => _.Id == b.GenreId).Name,
                    Author = _context.Authors.FirstOrDefault(_ => _.Id == b.AuthorId).Name,
                    PublishYear = b.PublishYear,
                    Count = b.Count,
                    RentedCount = b.RentedCount,
                }).ToList();
                return book;
            }
            else if(genre != null)
            {
                var GenreId = _context.Genres.FirstOrDefault(_ => _.Name == genre).Id;
                var book = _context.Books.Where(_ => _.GenreId == GenreId).Select(b => new GetBookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = _context.Genres.FirstOrDefault(_ => _.Id == b.GenreId).Name,
                    Author = _context.Authors.FirstOrDefault(_ => _.Id == b.AuthorId).Name,
                    PublishYear = b.PublishYear,
                    Count = b.Count,
                    RentedCount = b.RentedCount,
                }).ToList();
                return book;
            }
            else
            {
                return _context.Books.Select(b => new GetBookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = _context.Genres.FirstOrDefault(_ => _.Id == b.GenreId).Name,
                    Author = _context.Authors.FirstOrDefault(_ => _.Id == b.AuthorId).Name,
                    Count = b.Count,
                    RentedCount = b.RentedCount,
                    PublishYear = b.PublishYear,

                }).ToList();
            }
        }
        public void RentBook([FromBody] RentBookDto dto)
        {
            var userId = _context.Users.FirstOrDefault(_ => _.Name == dto.UserName).Id;
            var bookId = _context.Books.FirstOrDefault(_ => _.Title == dto.BookTitle).Id;
            var validRentedCount = _context.RentedBooks.Where(_ => _.UserId == userId).Where(_ => _.Condition == BookCondition.Rented).Count();
            var book = _context.Books.FirstOrDefault(_ => _.Id == bookId);
            var bookCount = book.Count;
            if (bookCount > 0)
            {
                if (validRentedCount < 4)
                {
                    var rentBook = new RentedBook()
                    {
                        Condition = BookCondition.Rented,
                        UserId = _context.Users.FirstOrDefault(_ => _.Name == dto.UserName).Id,
                        BookId = _context.Books.FirstOrDefault(_ => _.Title == dto.BookTitle).Id,
                    };
                    book.RentedCount++;
                    book.Count--;
                    _context.RentedBooks.Add(rentBook);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("The user cannot rent more than 4 books at the same time.");
                }
            }
            else
            {
                throw new Exception("The book is out of stock");
            }


        }
        public void ReturnBook([FromBody] ReturnBookDto dto)
        {
            var userId = _context.Users.FirstOrDefault(_ => _.Name == dto.UserName).Id;
            var bookId = _context.Books.FirstOrDefault(_ => _.Title == dto.BookTitle).Id;
            var book = _context.Books.FirstOrDefault(_ => _.Id == bookId);
            book.RentedCount--;
            book.Count++;
            var rentedBook = _context.RentedBooks.Where(_ => _.UserId == userId).FirstOrDefault(_ => _.BookId == bookId);
            rentedBook.Condition = BookCondition.BroughtBack;
            _context.SaveChanges();
        }
    }
}

