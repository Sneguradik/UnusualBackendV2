using Microsoft.IdentityModel.Protocols;
using UnusualBackend.Models;

namespace UnusualBackend.Services;

public interface IFilterService
{
    IEnumerable<TradeStatAnalyzed> ApplyFilters(IEnumerable<TradeStatsDto> trades, IEnumerable<Filter> filters);
}

public class FilterService : IFilterService
{
    private static string TransformName(string name) => string
        .Join(string.Empty, name
            .Split("_")
            .Select(x=>char
                .ToUpper(x[0]) + x[1..]));
    
    private static bool Filter(TradeStatAnalyzed trade, Filter filter)
    {
        var field = trade.GetType().GetProperty(TransformName(filter.Name));
        if (field is null) return false;
        
        double value = 0;
        
        if (field.PropertyType == typeof(DateTime)) value = 
            ((DateTime)field.GetValue(trade)! - 
             new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
            .TotalSeconds;
        else if (field.PropertyType == typeof(TimeSpan)) value = ((TimeSpan)field.GetValue(trade)!).TotalSeconds;
        else
        {
            if (!double.TryParse(field.GetValue(trade)!.ToString(), out value)) return false;
        };
        
        bool res = false;
        switch (filter.Condition)
        {
            case FilterCondition.Equals:
                res = Equals(value, filter.Value);
                break;
            case FilterCondition.Less:
                res = value < filter.Value;
                break;
            case FilterCondition.Greater:
                res = value > filter.Value;
                break;
            case FilterCondition.LessOrEquals:
                res = value <= filter.Value;
                break;
            case FilterCondition.GreaterOrEquals:
                res = value >= filter.Value;
                break;
            case FilterCondition.NotEquals:
                res = !Equals(value, filter.Value);
                break;
            default:
                res = false;
                break;
        }
        if (filter.UseTrigger && res) trade.TotalScore ++;
        if (!res && filter.Type == FilterType.And) trade.ToDelete = true;
        return res;
    }
    public IEnumerable<TradeStatAnalyzed> ApplyFilters(IEnumerable<TradeStatsDto> trades, IEnumerable<Filter> filters)
    {
        var analyzeResults = trades.Select(x => new TradeStatAnalyzed(x));
        
        analyzeResults = filters
            .Where(x=>x.Active == true)
            .Aggregate(analyzeResults, (current, filter) => current
                .Where(x => Filter(x, filter)));

        return analyzeResults.Where(x => !x.ToDelete);
    }
}