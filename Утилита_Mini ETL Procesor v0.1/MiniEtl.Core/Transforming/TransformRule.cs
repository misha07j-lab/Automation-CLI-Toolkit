using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEtl.Core.Transforming;

public class TransformRule
{
    public string Column { get; set; } = string.Empty;
    public string Operation { get; set; } = string.Empty; // upper, lower, trim
}

