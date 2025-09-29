using Newtonsoft.Json;
using System;

namespace Hyperliquid.Client.Websocket.Responses.Fills
{
    /// <summary>
    /// User fills response
    /// </summary>
    public class UserFillsResponse
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
        public Fill[] Fills { get; set; } = Array.Empty<Fill>();
    }
}