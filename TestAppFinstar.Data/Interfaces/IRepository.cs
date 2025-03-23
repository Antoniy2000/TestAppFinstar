namespace TestAppFinstar.Data.Interfaces;
public interface IRepository<T> where T : class
{
    Task AddRangeAsync(IEnumerable<T> items, CancellationToken ct);
    Task ClearAsync(CancellationToken ct);
    IQueryable<T> GetAll();
}
