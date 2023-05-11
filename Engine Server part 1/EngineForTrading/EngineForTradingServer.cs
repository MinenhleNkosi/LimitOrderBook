using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EngineForTrading.Core.Configuration;

namespace EngineForTrading.Core
{
    //9) Make the "EngineForTradingServer" class sealed as well for content protection.
    sealed class EngineForTradingServer : BackgroundService, IEngineForTradingServer
    {
        private readonly ILogger<EngineForTradingServer> _logger;
        private readonly EngineForTradingConfiguration _engineForTradingServerConfig;

        //2) Next hwe create a logger with dependency injection used, The "IOptions<>" is for 
        //the input parameter which may / may not be null which will prevent any problems
        public EngineForTradingServer(ILogger<EngineForTradingServer> logger, 
            IOptions<EngineForTradingConfiguration> config)
        {
            //3) Catch the null exception
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //4) We get the IOptions configuration initialized
            _engineForTradingServerConfig = config.Value ?? throw new ArgumentNullException(nameof(config));
            
        }

        //6) We implement the Ru() method from the interface
        public Task Run(CancellationToken token) => ExecuteAsync(token);


        //"BackgroungService" has a protected abstract method called "ExecuteAsync()" which we need to override in order to 
        // use our server, for that we will add a method on the IEngineForTradingServer" interface
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //21) This is for execution purpose
            _logger.LogInformation($"Started {nameof(EngineForTradingServer)}");
            //1) Here we create a server loop which we might need in the near future
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            _logger.LogInformation($"Stopped {nameof(EngineForTradingServer)}");
            return Task.CompletedTask;

        }
    }
}
