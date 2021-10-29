using BooksApi.Models;

namespace integrator.Models
{
    using integrator;
    using MongoDB.Driver;
    using System;
    public class IntegratorDbContext: IIntegratorDbContext
    {
        private readonly IMongoDatabase _db;
        public IntegratorDbContext(MongoDbConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<Todo> Todos => _db.GetCollection<Todo>("Todos");
        
        public IMongoCollection<Book> Books => _db.GetCollection<Book>("Books");
    }
}