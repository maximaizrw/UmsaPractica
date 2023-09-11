using Microsoft.EntityFrameworkCore;
using Umsa.DataAccess.Repositories.Interfaces;
using Umsa.Models;

namespace Umsa.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }


        
    }
}
