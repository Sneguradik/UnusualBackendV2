using UnusualBackend.Models.Auth;
using UnusualBackend.Models.TradeFiltering;

namespace UnusualBackend.Models.UsersSettings;

public class UserFilters
{
    public User User { get; set; } = new();
    public List<Filter> Filters { get; set; } = [];
}