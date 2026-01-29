using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Core.Processing;

public sealed record ProcessingResult(
    SummaryBuilder Summary);
