using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTrading.Core
{
    internal interface IEngineForTradingServer
    {
        Task Run(CancellationToken token);
    }
}
