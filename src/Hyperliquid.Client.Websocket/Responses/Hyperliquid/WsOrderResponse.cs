using Newtonsoft.Json;
using System;
using Hyperliquid.Client.Websocket.Json;

namespace Hyperliquid.Client.Websocket.Responses.Hyperliquid
{
    /// <summary>
    /// Basic order information
    /// </summary>
    public class WsBasicOrder
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

    /// <summary>
    /// Order update response
    /// </summary>
    public class WsOrderResponse
    {
        /// <summary>
        /// Order information
        /// </summary>
        [JsonProperty("order")]
        public WsBasicOrder Order { get; set; } = new WsBasicOrder();

        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Status timestamp
        /// </summary>
        [JsonProperty("statusTimestamp")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime StatusTimestamp { get; set; }
    }
}