using LibraryManagment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.EntitiyMaps
{
    public class AuthorEntityMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> _)
        {
            _.ToTable("Authors");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name).IsRequired().HasMaxLength(50);

            _.HasMany(_ => _.books)
                .WithOne(_ => _.Author)
                .HasForeignKey(_ => _.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
