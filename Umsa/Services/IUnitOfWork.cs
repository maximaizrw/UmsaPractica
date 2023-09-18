using Umsa.DataAccess.Repositories;

namespace Umsa.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public RoleRepository RoleRepository { get; }

        Task<int> Complete();
    }
}