using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EngineForTradingServer.Logging.LoggingConfiguration;
using System.Threading.Tasks.Dataflow;

namespace EngineForTradingServer.Logging
{
    public class TextLogger : AbstractLogger, ITextLogger
    {
        private readonly LoggerConfiguration _loggingConfiguration;
        public TextLogger(IOptions<LoggerConfiguration> loggingConfiguration) : base()
        {
            _loggingConfiguration = loggingConfiguration.Value ?? throw new ArgumentNullException(nameof(loggingConfiguration));

            if (_loggingConfiguration.LoggerType != LoggerType.Text)
            {
                throw new InvalidOperationException($"{nameof(TextLogger)} doesn't match LoggerType of {_loggingConfiguration.LoggerType}");
            }

            //47) Create a log directory
            var now = DateTime.Now;
            string logDirectory = null;
            if (_loggingConfiguration != null && _loggingConfiguration.TextLoggerConfiguration != null)
            {
                logDirectory = Path.Combine(_loggingConfiguration.TextLoggerConfiguration.Directory, $"{now:yyyy-MM-dd}");
            }
            //string logDirectory = Path.Combine(_loggingConfiguration.TextLoggerConfiguration.Directory, $"{now:yyyy-MM-dd}");

            //48) Next we create the log name
            string uniqueLogNname = $"{_loggingConfiguration.TextLoggerConfiguration.FileName}-{now:HH_mm_ss}";
            string baseLogName = Path.Combine(uniqueLogNname, _loggingConfiguration.TextLoggerConfiguration.FileExtension);

            //46) Create a fileppath we want to log into
            string filepath = Path.Combine(logDirectory, baseLogName);

            //If directory doesn't exist, create it
            Directory.CreateDirectory(logDirectory);
            _ =Task.Run(() => LogAsync(filepath, _logQueue, _tokenSource.Token));
        }

        private static async Task LogAsync(string filepath, BufferBlock<LogInformation> logQueue, CancellationToken token)
        {
            //38) We will cancel this Task usign the "token" in order for it to finish accordingly.Let's create the FileStream
            using var filestream = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);

            //39) We are going to write the above information down using StreamWriter
            using var streamwriter = new StreamWriter(filestream);

            //40) Since this is a long running Task, we use using above because we want to dispose the "streamwriter" object
            //as it inherits from "StreamWriter" and we gonna wrap it in a while loop.
            try
            {
                while(true)
                {
                    var logItem = await logQueue.ReceiveAsync(token).ConfigureAwait(false);
                    string formattedMessage = FormatLogItem(logItem);
                    await streamwriter.WriteAsync(formattedMessage).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {

            }
        }

        private static string FormatLogItem(LogInformation logItem)
        {
            //41) The first item we want to return is the time "logItem.Now:yyyy-MM-dd HH-mm-ss.fffffff".
            //42) The next thing we want to log is information to the thread that made a call to a specific.
            //level "{logItem.ThreadName, -30}:{logItem.ThreadId:000}".
            //43) The next thing we wish to log is our log level (priority) "logItem.LogLevels".
            //44) Lastly we get the message "logItem.Message".
            return $"[{logItem.Now:yyyy-MM-dd HH-mm-ss.fffffff}] [{logItem.ThreadName, -30}:{logItem.ThreadId:000}]" +
                $"[{logItem.LogLevels}] {logItem.Message}";
        }

        protected override void Log(LogLevels logLevel, string module, string message)
        {
            //36) We simply going to call " post()" to pass the required parameters to our Queue:
            //37) Post() is an asynchronous post to the underlying queue to this bufferBlock
            _logQueue.Post(new LogInformation(logLevel, module, message, DateTime.Now,
                Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
        }

        //Think of this as a destructor
        ~TextLogger() 
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //46) Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            lock (_lock)
            {
                if (_dispose) return;
                _dispose = true;
            }

            if (disposing)
            {
                //47) Get rid of managed resources 
                _tokenSource.Cancel();
                _tokenSource.Dispose();
            }

            //48) Get rid of unmanaged resouurces (ex. Database collection/connection, file stream, etc).

        }

        //35) Implementing our Queue data structure
        private readonly BufferBlock<LogInformation> _logQueue = new BufferBlock<LogInformation>();

        //45) Let's add our cancellation token source that we are going to use in the constructor
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private bool _dispose = false;
        private readonly object _lock = new object();

    }
}
