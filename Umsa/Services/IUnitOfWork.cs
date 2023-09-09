namespace Umsa.Services
{
    public interface IUnitOfWork
    {
        Task<int> Complete();
        //SDFDS
    }
}
