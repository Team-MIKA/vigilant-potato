using BooksApi.Models;
using integrator.Models;
using MongoDB.Driver;

namespace integrator.Contexts
{
    public interface IMongoDbContext
    {
        IMongoCollection<Todo> Todos { get; }
        
        IMongoCollection<Book> Books { get; }
    }
}