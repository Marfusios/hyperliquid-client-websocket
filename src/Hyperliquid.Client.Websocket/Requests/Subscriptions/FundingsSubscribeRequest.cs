using Hyperliquid.Client.Websocket.Utils;
using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    public class FundingsSubscribeRequest : SubscribeRequestBase
    {
        public FundingsSubscribeRequest(string symbol)
        {
            BfxValidations.ValidateInput(symbol, nameof(symbol));

            Symbol = BitfinexSymbolUtils.FormatSymbolToFunding(symbol);
        }

        public override string Channel => "trades";
        public string Symbol { get; }
    }
}
