using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Migrations
{
    [Migration(202402020656)]
    public class _202402020656CreateAuthorAndGenreTable : Migration
    {
        public override void Up()
        {
            Create.Table("Authors")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();
            Create.Table("Genres")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();


        }
        public override void Down()
        {
            Delete.Table("Genres");
            Delete.Table("Authors");
        }

    }
}
