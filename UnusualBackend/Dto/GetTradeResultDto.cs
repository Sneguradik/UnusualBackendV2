﻿using UnusualBackend.Models;

namespace UnusualBackend.Dto;

public record GetTradeResultDto(DateTime StartDate, DateTime EndDate, string Currency, List<string> ExcludedCodes, Filter[] Filters);