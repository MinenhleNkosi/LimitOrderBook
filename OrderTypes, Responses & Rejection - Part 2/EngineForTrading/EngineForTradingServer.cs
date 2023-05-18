using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EngineForTradingServer.Core.Configuration;
using EngineForTradingServer.Logging;

namespace EngineForTradingServer.Core
{
    //9) Make the "EngineForTradingServer" class sealed as well for content protection.
    sealed class EngineForTradingServer : BackgroundService, IEngineForTradingServer
    {
        private readonly IOptions<EngineForTradingConfiguration> _engineForTradingServerConfig;
        private readonly ITextLogger _logger;

        //2) Next hwe create a logger with dependency injection used, The "IOptions<>" is for 
        //the input parameter which may / may not be null which will prevent any problems
        public EngineForTradingServer(IOptions<EngineForTradingConfiguration> engineForTradingServerConfig, ITextLogger textLoogger)
        {
            //3) We get the IOptions configuration initialized
            _engineForTradingServerConfig = engineForTradingServerConfig ?? throw new ArgumentNullException(nameof(engineForTradingServerConfig));

            //4) Catch the null exception
            _logger = textLoogger ?? throw new ArgumentNullException(nameof(textLoogger));
        }

        //6) We implement the Ru() method from the interface
        public Task Run(CancellationToken token) => ExecuteAsync(token);


        //"BackgroungService" has a protected abstract method called "ExecuteAsync()" which we need to override in order to 
        // use our server, for that we will add a method on the IEngineForTradingServer" interface
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //21) This is for execution purpose
            _logger.Information(nameof(EngineForTradingServer), "Starting Trading Engine");
            //1) Here we create a server loop which we might need in the near future
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            //22) This is for execution purpose
            _logger.Information(nameof(EngineForTradingServer), "Stopping Trading Engine");
            return Task.CompletedTask;

        }
    }
}
