using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Api.Service.Books.Dto
{
    public class AddBookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string PublishYear { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Count { get; set; }

    }
}
