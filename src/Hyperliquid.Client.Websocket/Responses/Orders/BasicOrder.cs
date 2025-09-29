using System;
using Hyperliquid.Client.Websocket.Json;
using Hyperliquid.Client.Websocket.Enums;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Orders
{
    /// <summary>
    /// Basic order information
    /// </summary>
    public class BasicOrder
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
        [JsonConverter(typeof(SideConverter))]
        public Side Side { get; set; } = Side.Unknown;

        /// <summary>
        /// Limit price
        /// </summary>
        [JsonProperty("limitPx")]
        public double LimitPrice { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [JsonProperty("sz")]
        public double Size { get; set; }

        /// <summary>
        /// Order ID
        /// </summary>
        [JsonProperty("oid")]
        public long OrderId { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Original size
        /// </summary>
        [JsonProperty("origSz")]
        public double OriginalSize { get; set; }

        /// <summary>
        /// Client order ID
        /// </summary>
        [JsonProperty("cloid")]
        public string? ClientOrderId { get; set; }
    }
}