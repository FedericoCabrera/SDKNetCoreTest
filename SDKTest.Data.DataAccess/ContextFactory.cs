using Microsoft.EntityFrameworkCore;

namespace SDKTest.Data.DataAccess
{
    public class ContextFactory
    {
        public static SDKTestDbContext GetMemoryContext(string nameBd)
        {
            var builder = new DbContextOptionsBuilder<SDKTestDbContext>();
            return new SDKTestDbContext(GetMemoryConfig(builder, nameBd));
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd)
        {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }
    }
}
