using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Core.Models;

public sealed class LogEntry
{
    public DateTime? Timestamp { get; init; }
    public LogLevel Level { get; init; }
    public string Message { get; init; } = string.Empty;
    public string RawLine { get; init; } = string.Empty;
}

