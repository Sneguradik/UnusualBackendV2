using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using UnusualBackend.Models;
using UnusualBackend.Utils;

namespace UnusualBackend.Services;

public interface IFilterService
{
    Task<IEnumerable<TradeStatAnalyzed>> ApplyFilters(IQueryable<TradeStatsDto> trades, IEnumerable<Filter> filters, CancellationToken token = default);
}

public class FilterService : IFilterService
{
    public async Task<IEnumerable<TradeStatAnalyzed>> ApplyFilters(
        IQueryable<TradeStatsDto> trades,
        IEnumerable<Filter> filters,
        CancellationToken token = default)
    {
        var active = filters.Where(f => f.Active).ToList();
        var andFilters = active.Where(f => f.Type == FilterType.And).ToList();
        var orFilters = active.Where(f => f.Type == FilterType.Or).ToList();
        
        var andTriggers = andFilters.Count(f => f.UseTrigger);

        
        var combined = andFilters
            .Select(PredicateBuilder.Build)
            .Aggregate<Expression<Func<TradeStatsDto, bool>>?, Expression<Func<TradeStatsDto, bool>>?>(null, (current, p) => current == null ? p : current.And(p));

        if (combined != null)
            trades = trades.Where(combined);

        var result = await trades
            .AsNoTracking()
            .Select(x => new TradeStatAnalyzed(x){TotalScore = andTriggers})
            .ToListAsync(token);

        
        foreach (var trade in from f in orFilters from trade in result where PredicateBuilder.Build(f).Compile()(trade) select trade)
            trade.TotalScore++;

        return result;
    }
}