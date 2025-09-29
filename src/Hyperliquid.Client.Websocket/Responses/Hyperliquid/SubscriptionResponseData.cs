using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Hyperliquid
{
    /// <summary>
    /// Subscription response
    /// </summary>
    public class SubscriptionResponseData
    {
        /// <summary>
        /// Channel name
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; } = string.Empty;

        /// <summary>
        /// Original subscription data
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; } = new object();
    }
}