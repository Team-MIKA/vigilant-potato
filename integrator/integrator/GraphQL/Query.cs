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
        [UseFirstOrDefault] // Not sure how to use this one??? https://chillicream.com/docs/hotchocolate/fetching-data/projections
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Book> GetBooks([Service] IBookService bookService){
            return bookService.Get();
        }
    }
}