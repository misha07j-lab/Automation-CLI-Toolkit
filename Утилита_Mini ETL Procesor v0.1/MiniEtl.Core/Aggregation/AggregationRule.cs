using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEtl.Core.Aggregation;

public class AggregationRule
{
    public string Column { get; set; } = string.Empty;
    public string Function { get; set; } = string.Empty; // count, sum, avg
}

