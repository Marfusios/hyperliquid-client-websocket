using System.Diagnostics;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Books
{
    /// <summary>
    /// Level in the order book
    /// </summary>
    [DebuggerDisplay("Level {Price}/{Size} ({NumberOfOrders})")]
    public class Level
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
}