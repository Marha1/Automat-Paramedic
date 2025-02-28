using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Automat_Paramedic
{
    public class DesignTimeApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=med;username=postgres;password=053352287");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}