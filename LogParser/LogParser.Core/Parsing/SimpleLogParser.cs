using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogParser.Core.Models;

namespace LogParser.Core.Parsing;

public sealed class SimpleLogParser : ILogParser
{
    public LogEntry Parse(string line)
    {
        return new LogEntry
        {
            RawLine = line,
            Message = line,
            Level = DetectLevel(line)
        };
    }

    private static LogLevel DetectLevel(string line)
    {
        var lower = line.ToLowerInvariant();

        if (lower.Contains("error")) return LogLevel.Error;
        if (lower.Contains("warn")) return LogLevel.Warning;
        if (lower.Contains("info")) return LogLevel.Info;
        if (lower.Contains("debug")) return LogLevel.Debug;
        if (lower.Contains("trace")) return LogLevel.Trace;

        return LogLevel.Unknown;
    }
}
