using Newtonsoft.Json;
using System;
using Hyperliquid.Client.Websocket.Json;

namespace Hyperliquid.Client.Websocket.Responses.Hyperliquid
{
    /// <summary>
    /// Trade data
    /// </summary>
    public class WsTradeResponse
    {
        /// <summary>
        /// Coin symbol
        /// </summary>
        [JsonProperty("coin")]
        public string Coin { get; set; } = string.Empty;

        /// <summary>
        /// Side (buy/sell)
        /// </summary>
        [JsonProperty("side")]
        public string Side { get; set; } = string.Empty;

        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("px")]
        public double Price { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [JsonProperty("sz")]
        public double Size { get; set; }

        /// <summary>
        /// Transaction hash
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// Trade ID
        /// </summary>
        [JsonProperty("tid")]
        public long TradeId { get; set; }

        /// <summary>
        /// Users involved in the trade [buyer, seller]
        /// </summary>
        [JsonProperty("users")]
        public string[] Users { get; set; } = new string[2];
    }
}