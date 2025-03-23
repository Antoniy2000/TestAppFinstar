namespace TestAppFinstar.Models.Options;
public class DataLoadParameters
{
    public static readonly DataLoadParameters Empty = new();

    public int? Skip { get; set; }
    public int? Take { get; set; } 
    public string? ValueContains { get; set; }
}
