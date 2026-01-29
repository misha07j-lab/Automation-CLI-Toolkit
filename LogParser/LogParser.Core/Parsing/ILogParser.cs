using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogParser.Core.Models;

namespace LogParser.Core.Parsing;

public interface ILogParser
{
    LogEntry Parse(string line);
}

