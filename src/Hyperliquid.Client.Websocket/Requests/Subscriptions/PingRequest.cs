namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    /// <summary>
    /// Subscribe to all mid prices
    /// </summary>
    public class PingRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Ping method
        /// </summary>
        public override string Method => "ping";

        /// <inheritdoc />
        public override object? Subscription => null;
    }
}
