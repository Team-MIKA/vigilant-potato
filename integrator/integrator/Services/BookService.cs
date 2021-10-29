using BooksApi.Models;
using integrator.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace integrator.Services
{
    public class BookService : IBookService
    {
        
        private readonly IIntegratorDbContext _context;

        public BookService(IIntegratorDbContext context)
        {
            _context = context;
        }

        public List<Book> Get() =>
            _context.Books.Find(book => true).ToList();

        public Book Get(string id) =>
            _context.Books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _context.Books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
            _context.Books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) =>
            _context.Books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) => 
            _context.Books.DeleteOne(book => book.Id == id);
    }
}