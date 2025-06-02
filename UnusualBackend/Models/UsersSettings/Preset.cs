using UnusualBackend.Models.Auth;
using UnusualBackend.Models.TradeFiltering;

namespace UnusualBackend.Models.UsersSettings;

public class Preset
{
    public int Id { get; set; }
    public User Owner { get; set; } = new();
    public bool IsDefault {get; set;}
    public string Currency { get; set; } = string.Empty;
    public string Exchange  { get; set; } = string.Empty;
    public List<string> ExcludedCodes { get; set; } = new();
    public List<Filter> Filters { get; set; } = new();
}