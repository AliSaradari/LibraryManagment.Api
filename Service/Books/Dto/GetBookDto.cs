namespace LibraryManagment.Api.Service.Books.Dto
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishYear { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }
        public int RentedCount { get; set; }


    }
}
