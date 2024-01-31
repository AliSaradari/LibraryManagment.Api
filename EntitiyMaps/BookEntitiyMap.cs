using LibraryManagment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.EntitiyMaps
{
    public class BookEntitiyMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> _)
        {
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Title).IsRequired().HasMaxLength(50);
            _.Property(_ => _.Author).IsRequired().HasMaxLength(50);
            _.Property(_ => _.PublishYear).IsRequired().HasMaxLength(50);
            _.Property(_ => _.Author).IsRequired().HasMaxLength(50);


        }
    }
}
