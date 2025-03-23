using TestAppFinstar.Models.DTO;
using TestAppFinstar.Models.Options;

namespace TestAppFinstar.Core.Interfaces;
public interface ITestAppFinstarService
{
    Task<bool> ImportDataAsync(IEnumerable<SomeDataStoreModel> data, CancellationToken ct);
    Task<SomeDataGetResult> GetDataAsync(DataLoadParameters? loadParameters, CancellationToken ct);
}