namespace TestAppFinstar.Models.DTO;
public class SomeDataGetResult
{
    public IEnumerable<SomeDataGetModel> Data { get; set; }
    public long TotalCount { get; set; }
}
