﻿namespace UnusualBackend.Models;

public class TradeStatAnalyzed : TradeStatsDto
{
    public int TotalScore { get; set; } = 0;
    
    public TradeStatAnalyzed() { }
    
    public TradeStatAnalyzed(TradeStatsDto dto) : base(dto) {}
}