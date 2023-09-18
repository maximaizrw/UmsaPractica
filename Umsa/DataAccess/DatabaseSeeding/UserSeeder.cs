﻿using Microsoft.EntityFrameworkCore;
using Umsa.Helpers;
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
                    Clave = PasswordEncryptHelper.EncryptPassword("1234"),
                    RoleId = 1
                }
                ); ;
        }
    }
}
