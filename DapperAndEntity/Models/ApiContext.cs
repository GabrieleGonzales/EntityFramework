using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EntityFrameworkCoreExample.Models
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
               (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UsersDb");
        }
        public DbSet<User> Users { get; set; }
    }
}
