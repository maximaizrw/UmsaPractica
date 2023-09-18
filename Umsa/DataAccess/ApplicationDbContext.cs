using Microsoft.EntityFrameworkCore;
using Umsa.DataAccess.DatabaseSeeding;
using Umsa.Models;

namespace Umsa.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new RoleSeeder()
            };

            foreach (var seeder in seeders)
            {
                seeder.SeedDatabse(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);

        }   
    }
}
