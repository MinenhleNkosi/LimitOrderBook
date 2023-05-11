using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Logging.LoggingConfiguration
{
    public class LoggerConfiguration
    {
        //33) We will use the "LoggerType" class to specify which configuration any constructor that takes in a configuration
        //can expect to take the proper configuration value 
        public LoggerType LoggerType { get; set; }
        public TextLoggerConfiguration? TextLoggerConfiguration { get; set; }
    }

    public class TextLoggerConfiguration
    {
        public string? Directory { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
    }
}
