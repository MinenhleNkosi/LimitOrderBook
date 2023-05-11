using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EngineForTrading.Core
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using var engine = EngineForTradingServerHostBuilder.BuildEngineForTradingServer();

            //18) setting the ServiceProvider credentials for the static property at "EngineForTradingServerServiceProvider"
            EngineForTradingServerServiceProvider.ServiceProvider = engine.Services;
            {
                //19) We create a scope in which our services will exists in
                using var scope = EngineForTradingServerServiceProvider.ServiceProvider.CreateScope();

                //20) Now we run our engine using asynchronous programming
                await engine.RunAsync().ConfigureAwait(false);

            }
        }
    }
}