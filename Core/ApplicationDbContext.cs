using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }

    }
}
