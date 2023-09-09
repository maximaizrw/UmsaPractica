using Microsoft.EntityFrameworkCore;
using Umsa.Models;

namespace Umsa.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Maxi",
                    LastName = "Maiz",
                    Email = "maxi@gmail.com",
                    Clave = "1234",
                }
                );
        }
    }
}
