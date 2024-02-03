using LibraryManagment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.EntitiyMaps
{
    public class RentedBookEntityMap : IEntityTypeConfiguration<RentedBook>
    {
        public void Configure(EntityTypeBuilder<RentedBook> _)
        {
            _.ToTable("RentedBooks");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();

            _.HasOne(_ => _.User)
                .WithMany(_ => _.RentedBooks)
                .HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            _.HasOne(_ => _.Book)
                .WithMany(_ => _.RentedBooks)
                .HasForeignKey(_ => _.BookId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
