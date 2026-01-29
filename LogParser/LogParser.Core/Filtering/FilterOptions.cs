using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogParser.Core.Models;

namespace LogParser.Core.Filtering;

public sealed class FilterOptions
{
    public List<string> Contains { get; init; } = new();
    public List<string> Excludes { get; init; } = new();

    public string? RegexPattern { get; init; }

    public List<LogLevel> Levels { get; init; } = new();

    public DateTime? From { get; init; }
    public DateTime? To { get; init; }

    public int? MaxLines { get; init; }
}
