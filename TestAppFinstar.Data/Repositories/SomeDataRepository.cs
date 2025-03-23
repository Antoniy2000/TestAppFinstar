using Microsoft.EntityFrameworkCore;
using TestAppFinstar.Data.Contexts;
using TestAppFinstar.Data.Interfaces;
using TestAppFinstar.Models.Entities;

namespace TestAppFinstar.Data.Repositories;
public class SomeDataRepository(MainDbContext dbContext) : IRepository<SomeData>
{
    public async Task AddRangeAsync(IEnumerable<SomeData> items, CancellationToken ct)
    {
        await dbContext.AddRangeAsync(items, ct);
        await dbContext.SaveChangesAsync(ct);
    }

    public Task ClearAsync(CancellationToken ct)
    {
        return dbContext.Set<SomeData>().ExecuteDeleteAsync(ct);
    }

    public IQueryable<SomeData> GetAll()
    {
        return dbContext.Set<SomeData>();
    }
}
