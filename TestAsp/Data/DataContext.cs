using Microsoft.EntityFrameworkCore;
using TestAsp.Models;

namespace TestAsp.Data
{
    public class DataContext : DbContext
    {
		public DataContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Livre> Livres
		{ get; set; }

        public class DbContextOptions<T>
        {
        }
        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
