using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }  // Example DbSet
    }
}
