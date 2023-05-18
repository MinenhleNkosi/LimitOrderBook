namespace EngineForTradingServer.Orders
{
    public interface IOrderCore
    {
        public long OrderId { get; } //50) Only getters, because we dn't want the orderCore to be set by anyone
        public string Username { get; } //same as above
        public int SecurityId { get; } //same as above

    }
}