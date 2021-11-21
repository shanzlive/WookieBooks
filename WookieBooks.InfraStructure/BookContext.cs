using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WookieBooks.Domain.Models;

namespace WookieBooks.InfraStructure
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
                : base(options)
        {

        }
        public DbSet<Book> Books { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Author = "J.K. Rowling", Title = "Harry Potter", Description = "Harry Potter Series", CoverImage = "harry_potter.jpg", Price = 110 },
                new Book { Id = 2, Author = "George R. R. Martin", Title = "A Song of Ice and Fire", Description = "Game of thrones", CoverImage = "game_of_thrones.jpg", Price = 120 }
            );
        }
    }
}
