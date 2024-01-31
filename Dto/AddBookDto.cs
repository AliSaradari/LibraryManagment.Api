using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Api.Dto
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

    }
}
