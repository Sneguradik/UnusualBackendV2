namespace UnusualBackend.Models;

public class TradeStatsDto
{
    public string Currency { get; set; } = string.Empty;
    public string TradeMemberName { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public string ClientCode { get; set; } = string.Empty;
    public string ClientLegalCode { get; set; } = string.Empty;

    public int ContraClientsQty { get; set; }
    public int TradedAssets { get; set; }
    public int DealsQty { get; set; }
    public decimal AvgDealsPerContra { get; set; }
    public int OrdersQty { get; set; }
    public decimal AvgOrdersPerContra { get; set; }
    public decimal AvgOrdersPerAsset { get; set; }

    public TimeSpan? MinDealTime { get; set; }
    public TimeSpan? MaxDealTime { get; set; }
    public double DealTimeDelta { get; set; }
    public double AvgTimeBtwOrdersSecs { get; set; }

    public decimal VolMoney { get; set; }
    public decimal AvgVolPerContra { get; set; }
    public decimal VolLots { get; set; }
    public decimal AvgDealVol { get; set; }
    public decimal MaxDealVol { get; set; }
    public decimal AvgDealPrice { get; set; }

    public decimal FinRes { get; set; }
    public decimal FinResAbs { get; set; }
    public decimal FinResExt { get; set; }
    public decimal FinResExtAbs { get; set; }
    public decimal FinResInt { get; set; }
    public decimal FinResIntAbs { get; set; }

    public decimal Cost { get; set; }
    
    public DateTime TradeDate { get; set; } 
}
