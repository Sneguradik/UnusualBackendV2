using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using UnusualBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opts=>opts.AddDefaultPolicy(policy=>policy
    .WithOrigins(builder.Configuration.GetSection("TrustedOrigins").Get<string[]>()!) 
    .AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod()
    .SetPreflightMaxAge(TimeSpan.FromMinutes(10))));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<TradeDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("SPBE"));
    opt.UseSnakeCaseNamingConvention();
});

builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IFilterService, FilterService>();
builder.Services.AddSingleton<IDefaultFilterService, DefaultFilterService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.MapOpenApi();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();

app.MapScalarApiReference(options =>
{
    options.WithTheme(ScalarTheme.Mars)
        .WithDarkMode(true)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
        .WithDarkModeToggle(false);
});

using (var scope = app.Services.CreateScope())
{
    var defaultFilterService = scope.ServiceProvider.GetRequiredService<IDefaultFilterService>();
    defaultFilterService.Load();
}

app.Run();