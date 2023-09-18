using Microsoft.EntityFrameworkCore;
using Umsa.Models;

namespace Umsa.DataAccess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Admin",
                    Activo = true,
                },
                new Role
                {
                    Id = 2,
                    Name = "Consulta",
                    Description = "Consulta",
                    Activo = true,
                });
        }
    }
}
