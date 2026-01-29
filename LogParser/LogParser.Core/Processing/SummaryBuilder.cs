using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogParser.Core.Models;

namespace LogParser.Core.Processing;

public sealed class SummaryBuilder
{
    private readonly Dictionary<LogLevel, int> _levelCounts = new();
    private int _totalLines;
    private int _matchedLines;

    public void RegisterTotal()
    {
        _totalLines++;
    }

    public void RegisterMatched(LogEntry entry)
    {
        _matchedLines++;

        if (!_levelCounts.ContainsKey(entry.Level))
            _levelCounts[entry.Level] = 0;

        _levelCounts[entry.Level]++;
    }

    public int TotalLines => _totalLines;
    public int MatchedLines => _matchedLines;

    public IReadOnlyDictionary<LogLevel, int> LevelCounts => _levelCounts;
}
