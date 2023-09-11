using Umsa.DataAccess.Repositories;

namespace Umsa.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }

        Task<int> Complete();
    }
}