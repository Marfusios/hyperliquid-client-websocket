using System;
using Hyperliquid.Client.Websocket.Json;
using Hyperliquid.Client.Websocket.Enums;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Fills
{
    /// <summary>
    /// Fill information
    /// </summary>
    public class Fill
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
        [JsonConverter(typeof(SideConverter))]
        public Side Side { get; set; }

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
        public double StartPosition { get; set; }

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
}