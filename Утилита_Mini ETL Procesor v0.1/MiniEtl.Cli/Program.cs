using MiniEtl.Core.Abstractions;
using MiniEtl.Core.Contracts;
using MiniEtl.Core.Filtering;
using MiniEtl.Core.Factories;
using MiniEtl.Core.IO;
using MiniEtl.Core.Processing;
using System;
using System.IO;
using System.Reflection;

namespace MiniEtl.Cli;

class Program
{
    private const string ToolName = "mini-etl";
    static async Task<int> Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Help
        if (args.Contains("--help"))
        {
            PrintUsage();
            return ExitCodes.Success;
        }

        // Version
        if (args.Contains("--version"))
        {
            Console.WriteLine($"{ToolName} v{GetVersion()}");
            return ExitCodes.Success;
        }

        // No arguments
        if (args.Length == 0)
        {
            PrintUsage();
            return ExitCodes.InvalidArguments;
        }

        ProcessingOptions? options = null;

        try
        {
            options = ParseArguments(args);

            if (options == null)
            {
                Console.Error.WriteLine("Invalid arguments. Use --help.");
                return ExitCodes.InvalidArguments;
            }

            if (options.Verbose && options.Quiet)
            {
                Console.Error.WriteLine("--verbose and --quiet cannot be used together.");
                return ExitCodes.InvalidArguments;
            }

            IDataProcessor processor = ProcessorFactory.Create(options);
            var exitCode = await processor.ProcessAsync(options);

            if (options.Verbose && exitCode == ExitCodes.Success)
            {
                Console.WriteLine("Processing completed successfully.");
            }
            return exitCode;
        }
        catch (FileNotFoundException ex)
        {
            if (options == null || !options.Quiet)
                Console.Error.WriteLine(ex.Message);

            return ExitCodes.FileNotFound;
        }
        catch (Exception ex)
        {
            if (options == null || !options.Quiet)
                Console.Error.WriteLine($"Error: {ex.Message}");

            return ExitCodes.ProcessingError;
        }
    }
    static string GetVersion()
    {
        return Assembly
            .GetExecutingAssembly()
            .GetName()
            .Version?
            .ToString() ?? "unknown";
    }

    private static ProcessingOptions? ParseArguments(string[] args)
    {
        var options = new ProcessingOptions();

        string? input = null;
        string? output = null;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i].ToLower())
            {
                case "--input":
                    if (i + 1 < args.Length)
                        input = args[++i];
                    break;

                case "--output":
                    if (i + 1 < args.Length)
                        output = args[++i];
                    break;

                case "--filter":
                    if (i + 1 < args.Length)
                    {
                        options.FilterExpression = args[++i];
                    }
                    break;
                case "--verbose":
                    options.Verbose = true;
                    break;

                case "--quiet":
                    options.Quiet = true;
                    break;
            }
        }

        if (string.IsNullOrWhiteSpace(input) ||
            string.IsNullOrWhiteSpace(output))
            return null;

        options.InputPath = input;
        options.OutputPath = output;

        return options;
    }


    private static void PrintUsage()
    {
        Console.WriteLine(@"
Console.WriteLine($@""...
Mini ETL Processor v{GetVersion()}
 (Studio Standard)
Usage:
  {ToolName} --input <file> --output <file> [options]
  mini-etl --input <file> --output <file> [options]

Required:
  --input <file>         Input CSV file
  --output <file>        Output CSV file

Optional:
  --filter ""expr""        Filter expression
  --transform ""expr""     Transform rules
  --aggregate ""expr""     Aggregation rules
  --version               Show version
  --help                  Show help

Exit Codes:
0  Success
1  Invalid arguments
2  File not found
3  Processing error
");
    }

}


