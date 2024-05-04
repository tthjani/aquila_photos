using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace APhoto.Data
{
    /// <summary>
    /// DbContextFactory for dotnet-ef migrations
    /// </summary>
    public class APhotosContextFactory : IDesignTimeDbContextFactory<APhotosContext>
    {
        public APhotosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<APhotosContext>();
            optionsBuilder.UseSqlServer(args[0]);

            return new APhotosContext(optionsBuilder.Options);
        }
    }
}
