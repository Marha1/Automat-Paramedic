using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;

namespace Automat_Paramedic.Repository
{
    public class ApplicationContextFactory
    {
        private readonly string _connectionString = @"host=localhost;port=5432;database=med;username=postgres;password=053352287";

        public ApplicationContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(_connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
