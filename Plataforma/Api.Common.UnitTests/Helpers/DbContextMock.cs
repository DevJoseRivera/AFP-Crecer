using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Api.Common.UnitTests.Helpers
{
    public static class DbContextMock
    {
        const string ConnectionString = "Server=localhost\\SQLEXPRESS01;Database=AFP-Crecer;Trusted_Connection=True;";

        public static AfpCrecerDbContext GetDsolutionsDbContext()
            => new AfpCrecerDbContext(new DbContextOptionsBuilder<AfpCrecerDbContext>().UseSqlServer(ConnectionString).Options);
    }
}
