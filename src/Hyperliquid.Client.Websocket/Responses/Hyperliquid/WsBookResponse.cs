using System;
using System.Diagnostics;
using Hyperliquid.Client.Websocket.Json;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Hyperliquid
{
    /// <summary>
    /// Level in the order book
    /// </summary>
    [DebuggerDisplay("Level {Price}/{Size} ({NumberOfOrders})")]
    public class WsLevel
    {
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
        /// Number of orders
        /// </summary>
        [JsonProperty("n")]
        public int NumberOfOrders { get; set; }
    }

    /// <summary>
    /// Order book response
    /// </summary>
    [DebuggerDisplay("Book Response {Coin} {Levels[0].Length} | {Levels[1].Length}")]
    public class WsBookResponse
    {
        /// <summary>
        /// Coin symbol
        /// </summary>
        [JsonProperty("coin")]
        public string Coin { get; set; } = string.Empty;

        /// <summary>
        /// Order book levels [bids, asks]
        /// </summary>
        [JsonProperty("levels")]
        public WsLevel[][] Levels { get; set; } = new WsLevel[2][];

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime Time { get; set; }
    }
}