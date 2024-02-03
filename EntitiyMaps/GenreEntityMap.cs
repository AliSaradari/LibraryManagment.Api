using LibraryManagment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.EntitiyMaps
{
    public class GenreEntityMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> _)
        {
            _.ToTable("Genres");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name).IsRequired().HasMaxLength(50);

            _.HasMany(_ => _.books)
                .WithOne(_ => _.Genre)
                .HasForeignKey(_ => _.GenreId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
