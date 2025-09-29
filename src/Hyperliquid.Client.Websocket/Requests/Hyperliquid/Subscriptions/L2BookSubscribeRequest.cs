using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Hyperliquid.Subscriptions
{
    /// <summary>
    /// Subscribe to L2 order book data for a specific coin
    /// </summary>
    public class L2BookSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for L2 book subscription
        /// </summary>
        /// <param name="coin">Coin symbol</param>
        /// <param name="nSigFigs">Number of significant figures (optional)</param>
        /// <param name="mantissa">Mantissa (optional)</param>
        public L2BookSubscribeRequest(string coin, int? nSigFigs = null, int? mantissa = null)
        {
            HlValidations.ValidateInput(coin, nameof(coin));

            _subscription = new
            {
                type = "l2Book",
                coin = coin
            };

            // Add optional parameters if provided
            if (nSigFigs.HasValue || mantissa.HasValue)
            {
                _subscription = new
                {
                    type = "l2Book",
                    coin = coin,
                    nSigFigs = nSigFigs,
                    mantissa = mantissa
                };
            }
        }

        private readonly object _subscription;

        /// <inheritdoc />
        public override object Subscription => _subscription;
    }
}