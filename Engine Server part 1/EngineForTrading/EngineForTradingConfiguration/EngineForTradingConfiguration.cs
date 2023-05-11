using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTrading.Core.Configuration
{
    public class EngineForTradingConfiguration
    {
        //We then get the json settings on the "EngineForTradingServerSettings" class
        public EngineForTradingServerSettings? EngineForTradingServerSettings { get; set; }
    }

    //12) This class corresponds to the json file details and gets the port number there.
    public class EngineForTradingServerSettings
    {
        public int Port { get; set;}
    }
}
