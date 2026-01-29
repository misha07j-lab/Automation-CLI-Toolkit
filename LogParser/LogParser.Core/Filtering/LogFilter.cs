using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using LogParser.Core.Models;

namespace LogParser.Core.Filtering;

public sealed class LogFilter
{
    private readonly FilterOptions _options;
    private readonly Regex? _regex;

    public LogFilter(FilterOptions options)
    {
        _options = options;

        if (!string.IsNullOrWhiteSpace(options.RegexPattern))
        {
            _regex = new Regex(
                options.RegexPattern,
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }

    public bool Match(LogEntry entry)
    {
        var line = entry.RawLine;

        // Contains (AND logic)
        if (_options.Contains.Any(c =>
            !line.Contains(c, StringComparison.OrdinalIgnoreCase)))
            return false;

        // Excludes
        if (_options.Excludes.Any(c =>
            line.Contains(c, StringComparison.OrdinalIgnoreCase)))
            return false;

        // Regex
        if (_regex != null && !_regex.IsMatch(line))
            return false;

        // Level
        if (_options.Levels.Any() &&
            !_options.Levels.Contains(entry.Level))
            return false;

        // Time range
        if (_options.From.HasValue &&
            entry.Timestamp.HasValue &&
            entry.Timestamp < _options.From)
            return false;

        if (_options.To.HasValue &&
            entry.Timestamp.HasValue &&
            entry.Timestamp > _options.To)
            return false;

        return true;
    }
}
