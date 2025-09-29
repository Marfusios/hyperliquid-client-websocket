namespace Hyperliquid.Client.Websocket.Requests.Hyperliquid.Subscriptions
{
    /// <summary>
    /// Subscribe to all mid prices
    /// </summary>
    public class AllMidsSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for all mids subscription
        /// </summary>
        /// <param name="dex">The perp dex to source mids from (optional)</param>
        public AllMidsSubscribeRequest(string? dex = null)
        {
            _subscription = new
            {
                type = "allMids"
            };

            if (dex != null)
            {
                _subscription = new
                {
                    type = "allMids",
                    dex
                };
            }
        }

        private readonly object _subscription;

        /// <inheritdoc />
        public override object Subscription => _subscription;
    }
}
