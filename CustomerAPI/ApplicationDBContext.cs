using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerAPI
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreator != null)
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
