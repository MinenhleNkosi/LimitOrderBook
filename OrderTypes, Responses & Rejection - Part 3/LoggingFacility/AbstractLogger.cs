using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Logging
{
    //30) Any class that derives from "AbstractLogger" will need to go ahead and override the "Log()" method based of it's
    //own given implementation.
    public abstract class AbstractLogger : ILogger
    {
        //Abstract classes should havew protected constructors.
        protected AbstractLogger()
        {
            
        }
        public void Debug(string module, string message) => Log(LogLevels.Debug, module, message);
        public void Debug(string module, Exception exception) => Log(LogLevels.Debug, module, exception.ToString());

        public void Information(string module, string message) => Log(LogLevels.Information, module, message);
        public void Information(string module, Exception exception) => Log(LogLevels.Information, module, exception.ToString());

        public void Warning(string module, string message) => Log(LogLevels.Warning, module, message);
        public void Warning(string module, Exception exception) => Log(LogLevels.Warning, module, exception.ToString());

        public void Error(string module, string message) => Log(LogLevels.Error, module, message);
        public void Error(string module, Exception exception) => Log(LogLevels.Error, module, exception.ToString());

        protected abstract void Log(LogLevels logLevel, string module, string message);
    }
}
