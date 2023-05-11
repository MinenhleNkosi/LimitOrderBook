using EngineForTradingServer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Rejects
{
    public sealed class RejectCreator
    {//This class will make use of the factory method

        public static Rejection GenerateOrderCoreRejection(IOrderCore rejectedOrder, RejectionReason rejectionReason)
        {
            return new Rejection(rejectedOrder, rejectionReason);
        }
    }
}
