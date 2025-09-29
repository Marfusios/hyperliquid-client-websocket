using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Enums
{
    /// <summary>
    /// Represents the side of an order or trade
    /// </summary>
    public enum Side
    {
        /// <summary>
        /// Unknown or unspecified side
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Bid (Buy)
        /// </summary>
        [JsonProperty("B")]
        Bid,

        /// <summary>
        /// Ask (Sell)
        /// </summary>
        [JsonProperty("A")]
        Ask
    }
}