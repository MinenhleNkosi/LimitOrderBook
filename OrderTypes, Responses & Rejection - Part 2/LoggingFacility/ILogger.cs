using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Logging
{
    //25) It represents the interface where all our loggers will need to abide to.
    public interface ILogger
    {
        //26) The declaration of our debug methods
        void Debug(string module, string message);
        void Debug(string module, Exception exception);


        //27) The declaration of our debug methods
        void Information(string module, string message);
        void Information(string module, Exception exception);


        //28) The declaration of our debug methods
        void Warning(string module, string message);
        void Warning(string module, Exception exception);


        //29) The declaration of our debug methods
        void Error(string module, string message);
        void Error(string module, Exception exception);
    }
}
