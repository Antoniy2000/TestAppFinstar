using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestAppFinstar.Core.Interfaces;
using TestAppFinstar.Data.Interfaces;
using TestAppFinstar.Models.DTO;
using TestAppFinstar.Models.Entities;
using TestAppFinstar.Models.Options;

namespace TestAppFinstar.Core.Services;
public class TestAppFinstarService(IRepository<SomeData> dataRepository, ILogger<TestAppFinstarService> logger) 
    : ITestAppFinstarService
{
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    public async Task<SomeDataGetResult> GetDataAsync(DataLoadParameters? loadParameters, CancellationToken ct)
    {
        loadParameters ??= DataLoadParameters.Empty;

        var query = dataRepository.GetAll();
        if (!string.IsNullOrEmpty(loadParameters.ValueContains))
        {
            query = query.Where(x => EF.Functions.Like(x.Value, $"%{loadParameters.ValueContains}%"));
        }

        try
        {
            var total = await query.LongCountAsync(ct);

            if (loadParameters.Skip.HasValue)
            {
                query = query.Skip(loadParameters.Skip.Value);
            }
            if (loadParameters.Take.HasValue)
            {
                query = query.Take(loadParameters.Take.Value);
            }

            var res = await query
                .ProjectToType<SomeDataGetModel>()
                .ToArrayAsync(ct);

            return new()
            {
                Data = res,
                TotalCount = total,
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Get data error");
            throw;
        }
    }

    public async Task<bool> ImportDataAsync(IEnumerable<SomeDataStoreModel> data, CancellationToken ct)
    {
        await _semaphore.WaitAsync(ct);
        try
        {
            var newData = data.OrderBy(x => x.Code).Select((x, i) => new SomeData
            {
                Ordinal = i + 1,
                Code = x.Code,
                Value = x.Value,
            });
            await dataRepository.ClearAsync(ct);
            await dataRepository.AddRangeAsync(newData, ct);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Import error");
        }
        finally
        {
            _semaphore.Release();
        }

        return false;
    }
}
