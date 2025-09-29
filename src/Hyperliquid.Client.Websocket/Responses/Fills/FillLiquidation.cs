using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Fills
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
}