using Microsoft.EntityFrameworkCore;

namespace Umsa.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabse(ModelBuilder modelBuilder);
    }
}
