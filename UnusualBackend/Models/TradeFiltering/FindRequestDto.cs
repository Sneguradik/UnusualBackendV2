namespace UnusualBackend.Models.TradeFiltering;

public class FindRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Exchange  { get; set; } = string.Empty;
    public List<Filter> Filters { get; set; } = new();
}