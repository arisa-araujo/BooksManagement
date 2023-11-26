using BooksManagement.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.API.Persistence
{
    public class BooksManagementDbContext : DbContext
    {
        public BooksManagementDbContext(DbContextOptions<BooksManagementDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(b =>
            {
                b.HasKey(bo => bo.Id);
            });

            builder.Entity<User>(u =>
            {
                u.HasKey(us => us.Id);
            });

            builder.Entity<BookLoan>(bl =>
            {
                bl.HasKey(l => l.Id);

                bl.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId);

                bl.HasOne(b => b.Book)
                    .WithMany()
                    .HasForeignKey(b => b.BookId);

            });
        }
    }
}