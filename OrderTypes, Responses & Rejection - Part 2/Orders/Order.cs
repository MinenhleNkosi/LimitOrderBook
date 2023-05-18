using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineForTradingServer.Orders
{
    public class Order : IOrderCore
    {
        public Order(IOrderCore orderCore, long price, uint initialQuantity, uint currentQuantity, bool isBuySide) 
        {
            Price = price;
            InitialQuantity = initialQuantity;
            CurrentQuantity = currentQuantity;
            IsBuySide = isBuySide;
        }

        public Order(ModifyOrder modifyOrder) : 
            this(modifyOrder, modifyOrder.Price, modifyOrder.Quantity, modifyOrder.IsBuySide)
        {

        }

        //Properties
        public long Price { get; private set; }
        public uint InitialQuantity { get; private set; }
        public uint CurrentQuantity { get; private set; }
        public bool IsBuySide { get; private set; }

        public long OrderId => _orderCore.OrderId;
        public string Username => _orderCore.Username;
        public int SecurityId => _orderCore.SecurityId;

        //Methods
        public void IncreaseQuantity(uint quantityDelta)
        {
            CurrentQuantity += quantityDelta;
        }

        public void DecreaseQuantity(uint quantityDelta)
        {
            if (quantityDelta > CurrentQuantity)
            {
                throw new InvalidOperationException($"Quanity Delta is greater than Current Delta for OrderId:{OrderId}");
            }
            CurrentQuantity -= quantityDelta;
        }


        // Fields
        private readonly IOrderCore _orderCore;
        private ModifyOrder modifyOrder;
        private uint quantity;
    }
}
