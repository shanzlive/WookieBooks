using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Domain.Models;

namespace WookieBooks.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default);
        //Task<List<Book>> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
        Task<List<Book>> GetByTitleOrAuthorAsync(string title, string author, CancellationToken cancellationToken = default);
        Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Book book, CancellationToken cancellationToken = default);
        Task UpdateAsync(Book book, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
