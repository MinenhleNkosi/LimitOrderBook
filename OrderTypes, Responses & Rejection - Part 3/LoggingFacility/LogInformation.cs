using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Logging
{
    //34) We will create a record type (Immutable). Use Pascal case when working with Records.
    public record LogInformation(LogLevels LogLevels, string Module, string Message, DateTime Now, int ThreadId, string? ThreadName)
    {
    }
}
