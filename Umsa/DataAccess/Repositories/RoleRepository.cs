using Microsoft.EntityFrameworkCore;
using Umsa.DataAccess.Repositories.Interfaces;
using Umsa.DTOs;
using Umsa.Helpers;
using Umsa.Models;

namespace Umsa.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(Role updateRole)
        {
            var Role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == updateRole.Id);
            if (Role == null)
                return false;

            Role.Name = updateRole.Name;
            Role.Description = updateRole.Description;
            Role.Activo = updateRole.Activo;


            _context.Roles.Update(Role);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {

            var Role = await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Role != null)
                _context.Roles.Remove(Role);


            return true;
        }

    }
}
