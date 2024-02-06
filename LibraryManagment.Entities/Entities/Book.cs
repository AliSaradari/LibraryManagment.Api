namespace LibraryManagment.Entities.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublishYear { get; set; }
        public int Count {  get; set; }
        public int RentedCount { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public HashSet<RentedBook> RentedBooks { get; set; }
    }
}
