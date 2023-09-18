using Microsoft.EntityFrameworkCore;
using Umsa.DataAccess.Repositories.Interfaces;
using Umsa.DTOs;
using Umsa.Helpers;
using Umsa.Models;

namespace Umsa.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        //Update user
        public override async Task<bool> Update(User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateUser.Id);
            if (user == null)
                return false;

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Clave = updateUser.Clave;

            _context.Users.Update(user);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {

            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
                _context.Users.Remove(user);


            return true;
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDTO dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave));
        }

    }
}
