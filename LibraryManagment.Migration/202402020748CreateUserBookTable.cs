using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Migrations
{
    [Migration(202402020748)]
    public class _202402020748CreateRentedBookTable : Migration
    {
        public override void Down()
        {
            Delete.Table("RentedBooks");
        }

        public override void Up()
        {
            Create.Table("RentedBooks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("BookId").AsInt32().NotNullable()
                  .ForeignKey("Fk_Books_RentedBooks", "Books", "Id")
                .WithColumn("UserId").AsInt32().NotNullable()
                  .ForeignKey("Fk_Users_RentedBooks", "Users", "Id")
                .WithColumn("Condition").AsInt32().NotNullable();

        }
    }
}
