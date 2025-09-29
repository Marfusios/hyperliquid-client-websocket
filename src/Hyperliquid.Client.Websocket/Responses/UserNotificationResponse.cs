using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses
{
    /// <summary>
    /// Notification response
    /// </summary>
    public class UserNotificationResponse
    {
        /// <summary>
        /// Notification message
        /// </summary>
        [JsonProperty("notification")]
        public string Notification { get; set; } = string.Empty;
    }
}