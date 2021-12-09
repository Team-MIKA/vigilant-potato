using System.Collections.Generic;
using System.Linq;
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
    }
}