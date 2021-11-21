using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Domain.Interfaces;
using WookieBooks.Domain.Models;

namespace WookieBooks.InfraStructure
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Books.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetByTitleOrAuthorAsync(string title, string author, CancellationToken cancellationToken = default)
        {
            var bookList = await _dbContext.Books.Where(x => (String.IsNullOrEmpty(title) || (x.Title == title)) && (String.IsNullOrEmpty(author) || (x.Author == author)))
                .ToListAsync();
            return bookList;
        }

        public async Task UpdateAsync(Book book, CancellationToken cancellationToken = default)
        {
            var booktoUpdate = _dbContext.Books.Where(x => x.Id.Equals(book.Id)).FirstOrDefault();
            booktoUpdate.Price = book.Price;
            booktoUpdate.Title = book.Title;
            booktoUpdate.Description = book.Description;
            booktoUpdate.CoverImage = book.CoverImage;
            await _dbContext.SaveChangesAsync();
        }

    }
}
