using _25_may.Models;
using Microsoft.EntityFrameworkCore;

namespace _25_may.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<History>histories { get; set; }
    }
}
