using UnusualBackend.Models.TradeFiltering;
using UnusualBackend.Models.UsersSettings;

namespace UnusualBackend.Dto.Presets;

public class CreatePresetDto
{
    public string Currency { get; set; } = string.Empty;
    public string Exchange  { get; set; } = string.Empty;
    public bool IsDefault { get; set; } 
    public List<string> ExcludedCodes { get; set; } = new();
    public List<Filter> Filters { get; set; } = new();
}

public class AuthorPresetDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class PresetDto :  CreatePresetDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; } 

    public PresetDto() { }

    public PresetDto(Preset preset)
    {
        Id = preset.Id;
        Currency = preset.Currency;
        Exchange  = preset.Exchange;
        ExcludedCodes = preset.ExcludedCodes;
        Filters = preset.Filters;
        OwnerId = preset.Id;
    }
}