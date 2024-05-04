using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
