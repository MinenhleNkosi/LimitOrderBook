using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Logging
{
    //32) Our main goal here is to is to not use the "ILogger" from the "EngineForTradingServer" class but use the
    //"TextLogger" class. We need to change the "ILogger<EngineForTradingServer>" with the "ITextLogger".
    //IDisposable is inherited for freeing up resources (memory)
    public interface ITextLogger : ILogger, IDisposable
    {
    }
}
