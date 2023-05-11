using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Logging
{
    //31) This enum will represent the type of a logger since there can be more than one type, it can be a textLogger,
    //a databaseLogger, or a traceLogger, etc.
    public enum LoggerType
    {
        Text,      //Implementing
        Database,  //Not implementing
        Trace,    //Not implementing
        Console   //Not implementing
    }
}
