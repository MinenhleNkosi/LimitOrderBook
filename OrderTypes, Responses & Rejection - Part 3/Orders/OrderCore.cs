using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Orders
{
    public class OrderCore : IOrderCore
    {
        //51) This class is immutable because we can only get this fields but we can't set them because the "set" in done 
        //privately and its done on the constructor.
        public long OrderId { get; private set; }
        public string Username { get; private set; }
        public int SecurityId { get; private set; }
        public OrderCore(long orderId, string username, int securityId)
        {
            OrderId = orderId;
            Username = username;
            SecurityId = securityId;
        }

    }
}
