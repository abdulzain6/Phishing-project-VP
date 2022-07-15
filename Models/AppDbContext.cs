using Microsoft.EntityFrameworkCore;

namespace VpTaskWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MyModel>? DataModels { get; set; }
    }
}
