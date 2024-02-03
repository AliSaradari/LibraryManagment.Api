using LibraryManagment.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.EntitiyMaps
{
    public class EFDataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=LibraryManagment;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);    
        }
    }
}
