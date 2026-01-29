using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using LogParser.Core.Models;

namespace LogParser.Core.Parsing;

public sealed class RegexLogParser : ILogParser
{
    private readonly Regex _regex;

    public RegexLogParser(string pattern)
    {
        _regex = new Regex(pattern,
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public LogEntry Parse(string line)
    {
        var match = _regex.Match(line);

        if (!match.Success)
        {
            return new LogEntry
            {
                RawLine = line,
                Message = line,
                Level = LogLevel.Unknown
            };
        }

        DateTime? timestamp = null;
        if (match.Groups["ts"].Success &&
            DateTime.TryParse(match.Groups["ts"].Value, out var parsed))
        {
            timestamp = parsed;
        }

        var level = LogLevel.Unknown;
        if (match.Groups["level"].Success)
        {
            level = ParseLevel(match.Groups["level"].Value);
        }

        var message = match.Groups["msg"].Success
            ? match.Groups["msg"].Value
            : line;

        return new LogEntry
        {
            Timestamp = timestamp,
            Level = level,
            Message = message,
            RawLine = line
        };
    }

    private static LogLevel ParseLevel(string value)
    {
        return value.ToLowerInvariant() switch
        {
            "error" => LogLevel.Error,
            "warn" or "warning" => LogLevel.Warning,
            "info" => LogLevel.Info,
            "debug" => LogLevel.Debug,
            "trace" => LogLevel.Trace,
            _ => LogLevel.Unknown
        };
    }
}
