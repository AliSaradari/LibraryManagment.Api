using LibraryManagment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.EntitiyMaps
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> _)
        {
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name).IsRequired().HasMaxLength(50);
            _.Property(_ => _.Email).IsRequired().HasMaxLength(50);
        }
    }
}
