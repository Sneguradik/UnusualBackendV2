using UnusualBackend.Models;
using UnusualBackend.Models.TradeFiltering;

namespace UnusualBackend.Dto;

public record GetTradeResultDto(DateTime StartDate, DateTime EndDate, string Currency, List<string> ExcludedCodes, Filter[] Filters);