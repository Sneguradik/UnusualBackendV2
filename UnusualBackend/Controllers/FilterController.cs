using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnusualBackend.Dto;
using UnusualBackend.Models;
using UnusualBackend.Models.TradeFiltering;
using UnusualBackend.Services;
using UnusualBackend.Services.TradeFiltering;

namespace UnusualBackend.Controllers
{
    [Route("/filter")]
    [ApiController]
    public class FilterController(ITradeRepository tradeRepository, IDefaultFilterService defaultFilterService, IFilterService filterService, ILogger<FilterController> logger) : ControllerBase
    {
        
        [HttpPost]
        public async Task<ActionResult<TradeStatAnalyzed[]>> GetData([FromBody] GetTradeResultDto dto, CancellationToken token)
        {
            if (dto.StartDate > dto.EndDate) return Problem(title: "Invalid data", 
                statusCode: StatusCodes.Status400BadRequest, 
                detail: "Start date cannot be earlier than end date", 
                instance: HttpContext.Request.Path);
            logger
                .LogInformation($"Requested from {dto.StartDate:yyyy-MM-dd} to {dto.EndDate:yyyy-MM-dd}. Currency: {dto.Currency}.");
            var tradeStats = await filterService.ApplyFilters(tradeRepository
                .GetTradeResults(dto) , dto.Filters, token: token);
            logger
                .LogInformation($"Received from {dto.StartDate:yyyy-MM-dd} to {dto.EndDate:yyyy-MM-dd}. Currency: {dto.Currency}.");
            
            logger
                .LogInformation($"Filtered from {dto.StartDate:yyyy-MM-dd} to {dto.EndDate:yyyy-MM-dd}. Currency: {dto.Currency}.");
            return tradeStats.ToArray();
        }

        [HttpGet("default_filters/{currency}")]
        public List<Filter> GetDefaultFilters(string currency) => defaultFilterService[currency];
        
        
    }
}



