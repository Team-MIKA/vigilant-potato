using BooksApi.Models;

namespace integrator.Models
{
    using MongoDB.Driver;
    public interface IIntegratorDbContext
    {
        IMongoCollection<Todo> Todos { get; }
        
        IMongoCollection<Book> Books { get; }
    }
}