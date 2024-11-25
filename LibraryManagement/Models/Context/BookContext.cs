using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Book>()
               .HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Loan>()
          .HasOne(b => b.Book)
          .WithMany(b => b.Loans)
          .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Loan>()
             .HasOne(b => b.User)
             .WithMany(b => b.Loans)
             .HasForeignKey(b => b.UserId);

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Carousel> Carousel { get; set; }


    }
}
