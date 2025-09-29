using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses
{
    /// <summary>
    /// All mid prices response
    /// </summary>
    public class AllMidsResponse
    {
        /// <summary>
        /// All mid-prices by symbol
        /// </summary>
        [JsonProperty("mids")]
        public Dictionary<string, double> MidPrices { get; set; } = new Dictionary<string, double>();
    }
}