using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Hyperliquid
{
    /// <summary>
    /// Notification response
    /// </summary>
    public class HyperliquidNotificationResponse
    {
        /// <summary>
        /// Notification message
        /// </summary>
        [JsonProperty("notification")]
        public string Notification { get; set; } = string.Empty;
    }
}