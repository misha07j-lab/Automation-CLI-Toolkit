using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogParser.Core.Filtering;
using LogParser.Core.Models;
using LogParser.Core.Parsing;

namespace LogParser.Core.Processing;

public sealed class LogProcessor
{
    public async Task<ProcessingResult> ProcessAsync(
        IEnumerable<string> files,
        ILogParser parser,
        FilterOptions options,
        string? outputPath,
        CancellationToken ct = default)
    {
        var filter = new LogFilter(options);
        var summary = new SummaryBuilder();

        using var writer = outputPath != null
            ? new StreamWriter(outputPath)
            : null;

        int written = 0;

        foreach (var file in files)
        {
            foreach (var line in File.ReadLines(file))
            {
                ct.ThrowIfCancellationRequested();

                summary.RegisterTotal();

                var entry = parser.Parse(line);

                if (!filter.Match(entry))
                    continue;

                summary.RegisterMatched(entry);

                if (writer != null)
                    await writer.WriteLineAsync(line);
                else
                    Console.WriteLine(line);

                written++;

                if (options.MaxLines.HasValue &&
                    written >= options.MaxLines.Value)
                    break;
            }
        }

        return new ProcessingResult(summary);
    }
}

