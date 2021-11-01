using integrator.Contexts;
using integrator.Models;

namespace integrator.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Bson;
    public class TodoService : ITodoService
    {
        private readonly IMongoDbContext _context;
        public TodoService(IMongoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context
                .Todos
                .Find(_ => true)
                .ToListAsync();
        }
        public Task<Todo> GetTodo(long id)
        {
            FilterDefinition<Todo> filter = Builders<Todo>.Filter.Eq(m => m.Id, id);
            return _context
                .Todos
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        public async Task Create(Todo todo)
        {
            await _context.Todos.InsertOneAsync(todo);
        }
        public async Task<bool> Update(Todo todo)
        {
            ReplaceOneResult updateResult =
                await _context
                    .Todos
                    .ReplaceOneAsync(
                        filter: g => g.Id == todo.Id,
                        replacement: todo);
            return updateResult.IsAcknowledged
                   && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<Todo> filter = Builders<Todo>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                .Todos
                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                   && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Todos.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}