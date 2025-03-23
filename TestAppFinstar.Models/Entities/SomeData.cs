using System.ComponentModel.DataAnnotations;

namespace TestAppFinstar.Models.Entities;
public class SomeData
{
    [Key]
    public long Ordinal { get; set; }

    public int Code { get; set; }
    public string Value { get; set; }
}
