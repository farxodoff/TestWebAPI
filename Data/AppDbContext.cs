using System.Data;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Entities;

namespace TestWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // PostgreSQL da jadval yaratadi
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
