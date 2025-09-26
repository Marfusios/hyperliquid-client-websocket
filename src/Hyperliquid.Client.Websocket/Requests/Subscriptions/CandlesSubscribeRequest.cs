﻿using Hyperliquid.Client.Websocket.Utils;
using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    public class CandlesSubscribeRequest : SubscribeRequestBase
    {
        public CandlesSubscribeRequest(string pair, BitfinexTimeFrame bitfinexTimeFrame)
        {
            BfxValidations.ValidateInput(pair, nameof(pair));

            Key = $"trade:{TimeFrameToKeyCommand(bitfinexTimeFrame)}:{BitfinexSymbolUtils.FormatPairToTradingSymbol(pair)}";
        }

        public override string Channel => "candles";
        public string Key { get; set; }

        private string TimeFrameToKeyCommand(BitfinexTimeFrame bitfinexTimeFrame)
        {
            return bitfinexTimeFrame.GetStringValue();
        }
    }
}
