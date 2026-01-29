using LogParser.Core.Filtering;
using LogParser.Core.Models;
using LogParser.Core.Parsing;
using LogParser.Core.Processing;

namespace LogParser.Cli;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        try
        {
            if (args.Length == 0 || args.Contains("--help"))
            {
                PrintHelp();
                return ExitCodes.InvalidArguments;
            }

            var options = ParseArgs(args);

            var files = ResolveInputFiles(options.InputPath);

            if (!files.Any())
            {
                Console.Error.WriteLine("Input file(s) not found.");
                return ExitCodes.InputNotFound;
            }

            ILogParser parser = new SimpleLogParser();

            var filterOptions = new FilterOptions
            {
                Contains = options.Contains,
                Excludes = options.Excludes,
                RegexPattern = options.Regex,
                Levels = options.Levels,
                MaxLines = options.MaxLines
            };

            var processor = new LogProcessor();

            var result = await processor.ProcessAsync(
                files,
                parser,
                filterOptions,
                options.OutputPath);

            PrintSummary(result);

            return ExitCodes.Success;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            return ExitCodes.ProcessingError;
        }
    }

    static void PrintHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  LogParser.exe --input <path> [options]");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --out <path>");
        Console.WriteLine("  --contains <text>");
        Console.WriteLine("  --exclude <text>");
        Console.WriteLine("  --regex <pattern>");
        Console.WriteLine("  --level <error,warning,info,debug,trace>");
        Console.WriteLine("  --max-lines <n>");
    }

    static CliOptions ParseArgs(string[] args)
    {
        var options = new CliOptions
        {
            InputPath = GetValue(args, "--input")
                ?? throw new ArgumentException("--input is required")
        };

        options.OutputPath = GetValue(args, "--out");
        options.Regex = GetValue(args, "--regex");

        options.MaxLines = int.TryParse(GetValue(args, "--max-lines"), out var max)
            ? max
            : null;

        options.Contains.AddRange(GetMultiple(args, "--contains"));
        options.Excludes.AddRange(GetMultiple(args, "--exclude"));

        var levelArg = GetValue(args, "--level");
        if (!string.IsNullOrWhiteSpace(levelArg))
        {
            foreach (var level in levelArg.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (Enum.TryParse<LogLevel>(level, true, out var parsed))
                    options.Levels.Add(parsed);
            }
        }

        return options;
    }

    static IEnumerable<string> ResolveInputFiles(string input)
    {
        if (File.Exists(input))
            return new[] { Path.GetFullPath(input) };

        var directory = Path.GetDirectoryName(input);
        var pattern = Path.GetFileName(input);

        if (string.IsNullOrWhiteSpace(directory))
            directory = Directory.GetCurrentDirectory();

        if (!Directory.Exists(directory))
            return Enumerable.Empty<string>();

        return Directory
            .EnumerateFiles(directory, pattern)
            .Select(Path.GetFullPath);
    }


    static string? GetValue(string[] args, string key)
    {
        var index = Array.IndexOf(args, key);
        if (index >= 0 && index < args.Length - 1)
            return args[index + 1];

        return null;
    }

    static IEnumerable<string> GetMultiple(string[] args, string key)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == key && i < args.Length - 1)
                yield return args[i + 1];
        }
    }

    static void PrintSummary(ProcessingResult result)
    {
        Console.WriteLine();
        Console.WriteLine("Summary:");
        Console.WriteLine($"Total lines: {result.Summary.TotalLines}");
        Console.WriteLine($"Matched lines: {result.Summary.MatchedLines}");

        foreach (var level in result.Summary.LevelCounts)
        {
            Console.WriteLine($"{level.Key}: {level.Value}");
        }
    }
}
