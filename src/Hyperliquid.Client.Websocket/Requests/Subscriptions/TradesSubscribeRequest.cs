using Hyperliquid.Client.Websocket.Utils;
using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    /// <summary>
    /// Subscribe to trades request
    /// </summary>
    public class TradesSubscribeRequest : SubscribeRequestBase
    {
        /// <summary>
        /// Subscribe to trades request
        /// </summary>
        /// <param name="pair">Target pair, for example 'BTC/USD', 'ETH/USD', ETHBTC, etc.</param>
        public TradesSubscribeRequest(string pair)
        {
            BfxValidations.ValidateInput(pair, nameof(pair));

            Symbol = BitfinexSymbolUtils.FormatPairToTradingSymbol(pair);
        }

        public override string Channel => "trades";
        public string Symbol { get; }
    }
}
