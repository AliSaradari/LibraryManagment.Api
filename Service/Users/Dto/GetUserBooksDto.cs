using LibraryManagment.Entities.Entities;

namespace LibraryManagment.Api.Service.Users.Dto
{
    public class GetUserBooksDto
    {
        public string Title { get; set; }
        public BookCondition Condition { get; set; }
    }
}
