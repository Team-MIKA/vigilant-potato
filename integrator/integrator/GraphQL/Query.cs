using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using integrator.Contexts;
using integrator.Models;
using integrator.Services;
using MongoDB.Driver;

namespace integrator.GraphQL
{
    
    public class Query
    {

        // The correct order is UsePaging > UseProjection > UseFiltering > UseSorting
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Book> GetBooks([Service] IMongoDbContext context){
            return context.Books.Find(_ => true).ToList();
        }
    }
}