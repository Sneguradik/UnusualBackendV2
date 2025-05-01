namespace UnusualBackend.Models.TradeFiltering;

public enum FilterCondition
{
    Equals,
    Less,
    Greater,
    LessOrEquals,
    GreaterOrEquals,
    NotEquals,
}

public enum FilterType
{
    And,
    Or
}

public class Filter
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public FilterCondition Condition { get; set; }
    public double Value { get; set; }
    public FilterType Type { get; set; }
    public bool UseTrigger  { get; set; } = true;
    public bool Active { get; set; } = true;
}