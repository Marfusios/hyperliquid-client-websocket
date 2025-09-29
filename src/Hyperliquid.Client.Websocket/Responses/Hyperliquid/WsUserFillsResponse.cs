using Newtonsoft.Json;
using System;
using Hyperliquid.Client.Websocket.Json;

namespace Hyperliquid.Client.Websocket.Responses.Hyperliquid
{
    /// <summary>
    /// Fill liquidation information
    /// </summary>
    public class FillLiquidation
    {
        /// <summary>
        /// Liquidated user
        /// </summary>
        [JsonProperty("liquidatedUser")]
        public string? LiquidatedUser { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        [JsonProperty("markPx")]
        public double MarkPrice { get; set; }

        /// <summary>
        /// Liquidation method
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; } = string.Empty;
    }

    /// <summary>
    /// Fill information
    /// </summary>
    public class WsFill
    {
        /// <summary>
        /// Coin symbol
        /// </summary>
        [JsonProperty("coin")]
        public string Coin { get; set; } = string.Empty;

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
        /// Side (buy/sell)
        /// </summary>
        [JsonProperty("side")]
        public string Side { get; set; } = string.Empty;

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// Start position
        /// </summary>
        [JsonProperty("startPosition")]
        public string StartPosition { get; set; } = string.Empty;

        /// <summary>
        /// Direction
        /// </summary>
        [JsonProperty("dir")]
        public string Direction { get; set; } = string.Empty;

        /// <summary>
        /// Closed PnL
        /// </summary>
        [JsonProperty("closedPnl")]
        public double ClosedPnl { get; set; }

        /// <summary>
        /// Transaction hash
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// Order ID
        /// </summary>
        [JsonProperty("oid")]
        public long OrderId { get; set; }

        /// <summary>
        /// Whether order crossed the spread (was taker)
        /// </summary>
        [JsonProperty("crossed")]
        public bool Crossed { get; set; }

        /// <summary>
        /// Fee (negative means rebate)
        /// </summary>
        [JsonProperty("fee")]
        public double Fee { get; set; }

        /// <summary>
        /// Trade ID
        /// </summary>
        [JsonProperty("tid")]
        public long TradeId { get; set; }

        /// <summary>
        /// Liquidation information
        /// </summary>
        [JsonProperty("liquidation")]
        public FillLiquidation? Liquidation { get; set; }

        /// <summary>
        /// Fee token
        /// </summary>
        [JsonProperty("feeToken")]
        public string FeeToken { get; set; } = string.Empty;

        /// <summary>
        /// Builder fee
        /// </summary>
        [JsonProperty("builderFee")]
        public string? BuilderFee { get; set; }
    }

    /// <summary>
    /// User fills response
    /// </summary>
    public class WsUserFillsResponse
    {
        /// <summary>
        /// Whether this is a snapshot
        /// </summary>
        [JsonProperty("isSnapshot")]
        public bool? IsSnapshot { get; set; }

        /// <summary>
        /// User address
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// Array of fills
        /// </summary>
        [JsonProperty("fills")]
        public WsFill[] Fills { get; set; } = Array.Empty<WsFill>();
    }
}