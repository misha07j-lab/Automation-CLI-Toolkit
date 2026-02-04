using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogParser.Core.Models;

namespace LogParser.Cli;
public sealed class CliOptions
{
    public required string InputPath { get; set; }
    public string? OutputPath { get; set; }
    public List<string> Contains { get; set; } = new();
    public List<string> Excludes { get; set; } = new();
    public List<LogLevel> Levels { get; set; } = new();
    public bool Verbose { get; set; }
    public bool Quiet { get; set; }
    public string? Regex { get; set; }
    public int? MaxLines { get; set; }
}
