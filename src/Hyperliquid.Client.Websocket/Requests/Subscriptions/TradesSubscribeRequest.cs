using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    /// <summary>
    /// Subscribe to trades for a specific coin
    /// </summary>
    public class TradesSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for trades subscription
        /// </summary>
        /// <param name="coin">Coin symbol</param>
        public TradesSubscribeRequest(string coin)
        {
            HlValidations.ValidateInput(coin, nameof(coin));

            _subscription = new
            {
                type = "trades",
                coin = coin
            };
        }

        private readonly object _subscription;

        /// <inheritdoc />
        public override object Subscription => _subscription;
    }
}