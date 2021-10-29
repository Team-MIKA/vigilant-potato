using integrator.Models;
using MongoDB.Driver;

namespace integrator.Contexts
{
    public class MongoDbContext: IMongoDbContext
    {
        private readonly IMongoDatabase _db;
        public MongoDbContext(MongoDbConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<Todo> Todos => _db.GetCollection<Todo>("Todos");
        
        public IMongoCollection<Book> Books => _db.GetCollection<Book>("Books");
    }
}