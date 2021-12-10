using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Integrator.Tests.TestHelpers
{
    public static class DbContextHelper
    {
        public static Mock<DbSet<T>> MakeMockDbSet<T>(List<T> data) where T : class
        {
            var dataQueryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(dataQueryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(dataQueryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(dataQueryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => dataQueryable.GetEnumerator());

            return mockSet;
        }

        public static IntegratorContext MakeTestDbContext()
        {


            var options = new DbContextOptionsBuilder<IntegratorContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options;
            var context = new IntegratorContext(options);
            context.Database.EnsureCreated();

            return context;
        }
        
        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}