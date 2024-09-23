// using Core.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }

        // public DbSet<User>  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
