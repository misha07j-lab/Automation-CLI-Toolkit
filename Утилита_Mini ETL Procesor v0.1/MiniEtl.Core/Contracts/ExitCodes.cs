using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEtl.Core.Contracts
{
    public static class ExitCodes
    {
        public const int Success = 0;
        public const int InvalidArguments = 1;
        public const int FileNotFound = 2;
        public const int ProcessingError = 3;
    }

}
