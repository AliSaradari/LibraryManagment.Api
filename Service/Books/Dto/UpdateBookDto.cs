namespace LibraryManagment.Api.Service.Books.Dto
{
    public class UpdateBookDto
    {
        public string? Genre { get; set; }
        public string? PublishYear { get; set; }
        public string? Author { get; set; }
        public int? Count { get; set; }
    }
}
