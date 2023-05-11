using EngineForTrading.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTrading.Core
{
    //8) The "public sealed" is to make sure that no one can override the content of these class outside of this namespace
    public sealed class EngineForTradingServerHostBuilder
    {//7) The purpose of this class is to create a host builder that will host the application and run it 
        //as a background service. We need a static method that will return a host for us

        public static IHost BuildEngineForTradingServer()
            => Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                //10) We start with the configurations. We want to be able to add the ability to have ooptions in our services
                services.AddOptions();

                //11) Now we want to add a potential class to the configuration above. That class is going to be "EngineForTradingConfiguration"
                services.Configure<EngineForTradingConfiguration>(context.Configuration.GetSection(nameof(EngineForTradingConfiguration)));

                //13) Now we add our singleton objects to the host (on the lambda expression above).
                //Here we choose to use a singleton because anytime you want one instance in a type to be used everywhere
                //in the application you require it to be a singleton.
                services.AddSingleton<IEngineForTradingServer, EngineForTradingServer>();

                //14) Now we register the host to the dependency injection service
                services.AddHostedService<EngineForTradingServer>();

                //15) this is our fully instatiantion of our trading engine called "EngineForTrading..."

            }).Build();
    }
}
