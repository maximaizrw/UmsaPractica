using Microsoft.EntityFrameworkCore;
using Umsa.DataAccess.Repositories.Interfaces;
using Umsa.DTOs;
using Umsa.Models;

namespace Umsa.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDTO dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == dto.Clave);
        }       
     
    }
}
