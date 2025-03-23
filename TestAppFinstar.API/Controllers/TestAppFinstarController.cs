using Microsoft.AspNetCore.Mvc;
using TestAppFinstar.Core.Interfaces;
using TestAppFinstar.Models.DTO;
using TestAppFinstar.Models.Options;

namespace TestAppFinstar.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestAppFinstarController(ITestAppFinstarService service) : Controller
{
    [HttpGet]
    public async Task<ActionResult<SomeDataGetResult>> GetData([FromQuery] DataLoadParameters? loadParameters, CancellationToken ct = default)
    {
        var res = await service.GetDataAsync(loadParameters, ct);
        return Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> ImportData(IEnumerable<SomeDataStoreModel> storeModels, CancellationToken ct = default)
    {
        var res = await service.ImportDataAsync(storeModels, ct);
        return Ok(res);
    }
}
