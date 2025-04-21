using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnusualBackend.Dto;
using UnusualBackend.Models;
using UnusualBackend.Services;

namespace UnusualBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilterController(ITradeRepository tradeRepository) : ControllerBase
    {
        [HttpGet("sort")]
        public async Task<List<TradeStatsDto>> GetData( CancellationToken token)
        {
            var dto = new GetTradeResultDto(DateTime.Parse("2025-04-01"), DateTime.Parse("2025-04-30"), "RUB", [
                "S02","S04","R0105","R0105_02","SD198","AF205","28T6S","3LLA1","AL223","AL223_002","4V430","PO256","TS267","alrbm","rencm","TS287","derzm_MM","derzm_SEP_MM","KU234_003","skbmm", "mfbim"]);
            return await tradeRepository.GetTradeResults(dto).ToListAsync(cancellationToken: token);
        }
    }
}



