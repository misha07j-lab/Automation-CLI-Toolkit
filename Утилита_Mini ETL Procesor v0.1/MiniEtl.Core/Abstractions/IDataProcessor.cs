using MiniEtl.Core.Contracts;
using MiniEtl.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEtl.Core.Abstractions;

public interface IDataProcessor
{
    Task<int> ProcessAsync(ProcessingOptions options);
}


