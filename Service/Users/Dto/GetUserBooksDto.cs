using LibraryManagment.Entities.Entities;

namespace LibraryManagment.Api.Service.Users.Dto
{
    public class GetUserBooksDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public BookCondition Condition { get; set; }
    }
}
