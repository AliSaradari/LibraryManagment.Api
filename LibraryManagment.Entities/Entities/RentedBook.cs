using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Entities.Entities
{
    public class RentedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public BookCondition Condition { get; set; }

    }
    public enum BookCondition
    {
        Rented = 1,
        BroughtBack = 2
    }
}
