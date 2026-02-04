using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Cli;

public static class ExitCodes
{
    public const int Success = 0;
    public const int InvalidArguments = 1;
    public const int InputNotFound = 2;
    public const int ProcessingError = 3;
}
