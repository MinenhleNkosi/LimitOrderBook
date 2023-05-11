using EngineForTradingServer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Rejects
{
    public class Rejection : IOrderCore
    {
        public Rejection(IOrderCore rejectionOrder, RejectionReason rejectionReason)
        {
            RejectionReason = rejectionReason;

            _orderCore = rejectionOrder;

        }

        //Properties
        public RejectionReason RejectionReason { get; private set; }
        public long OrderId => _orderCore.OrderId;
        public string Username => _orderCore.Username;
        public int SecurityId => _orderCore.SecurityId;

        //Fields
        private readonly IOrderCore _orderCore;
    }
}
