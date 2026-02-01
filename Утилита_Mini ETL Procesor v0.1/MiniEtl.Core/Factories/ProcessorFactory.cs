using MiniEtl.Core.Abstractions;
using MiniEtl.Core.Contracts;
using MiniEtl.Core.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEtl.Core.Factories;

public static class ProcessorFactory
{
    public static IDataProcessor Create(ProcessingOptions options)
    {
        // Пока одна реализация

        return new MiniEtlProcessor();

        // В будущем:
        // if (options.Mode == "log")
        //     return new LogParserProcessor();
    }
}

