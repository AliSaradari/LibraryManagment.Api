using FluentMigrator;

namespace LibraryManagment.Migrations
{
    [Migration(202402020703)]
    public class _202402020703AddBookTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Books");
        }

        public override void Up()
        {
            Create.Table("Books")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("Title").AsString(50).NotNullable()
                 .WithColumn("PublishYear").AsString(50).NotNullable()
                 .WithColumn("Count").AsInt32().NotNullable()
                 .WithColumn("RentedCount").AsInt32().NotNullable().WithDefaultValue(0)
                 .WithColumn("AuthorId").AsInt32().NotNullable()
                    .ForeignKey("FK_Authors_Books", "Authors", "Id")
                 .WithColumn("GenreId").AsInt32().NotNullable()
                    .ForeignKey("Fk_Genres_Books", "Genres", "Id");




        }
    }
}
