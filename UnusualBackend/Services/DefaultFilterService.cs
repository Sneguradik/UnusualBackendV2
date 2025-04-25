using System.Text.Json;
using UnusualBackend.Models;

namespace UnusualBackend.Services;

public interface IDefaultFilterService
{
    void Load();
    List<Filter> this[string currency] { get; }
}

public class DefaultFilterService(ILogger<DefaultFilterService> logger) : IDefaultFilterService
{
    private readonly Dictionary<string, List<Filter>> _filters = new ();
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public void Load()
    {
        var files = Directory.GetFiles("./DefaultFilters", "*.json");
        foreach (var file in files)
        {
            _filters.Add(Path.GetFileNameWithoutExtension(file), LoadFile(file));
            logger.LogInformation($"Loaded default filters from: {file}");
        }
        
    }

    public List<Filter> this[string currency] => _filters[currency];

    private  List<Filter> LoadFile(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(stream);
        string json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<List<Filter>>(json, _options)?? 
               throw new JsonException($"Failed to load {path}");
    }
}