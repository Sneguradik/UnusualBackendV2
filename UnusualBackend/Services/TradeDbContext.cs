using Microsoft.EntityFrameworkCore;
using UnusualBackend.Models;

namespace UnusualBackend.Services;

public class TradeDbContext(DbContextOptions<TradeDbContext> options) : DbContext(options)
{
    public DbSet<TradeResult> TradeResults { get; set; }
    public DbSet<TradeBS> TradeBSs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TradeBS>(e =>
        {
            e.HasNoKey();
            e.ToView("vw_ARH_TradeBS");
        });
    }
}