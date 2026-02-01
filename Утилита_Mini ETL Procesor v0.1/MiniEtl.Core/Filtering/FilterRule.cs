using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEtl.Core.Filtering;

public enum FilterOperator
{
    Eq, Neq, Gt, Gte, Lt, Lte,
    Contains, StartsWith, EndsWith
}

public sealed record FilterRule(
    string Field,
    FilterOperator Operator,
    string Value);

