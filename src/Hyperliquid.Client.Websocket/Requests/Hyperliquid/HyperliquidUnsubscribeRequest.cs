using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Requests.Hyperliquid
{
    /// <summary>
    /// Unsubscribe from a specific data feed
    /// </summary>
    public class HyperliquidUnsubscribeRequest
    {
        /// <summary>
        /// Initialize unsubscribe request
        /// </summary>
        /// <param name="subscription">The subscription object that matches the original subscription</param>
        public HyperliquidUnsubscribeRequest(object subscription)
        {
            Method = "unsubscribe";
            Subscription = subscription;
        }

        /// <summary>
        /// Request method
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Subscription details to unsubscribe from
        /// </summary>
        [JsonProperty("subscription")]
        public object Subscription { get; set; }
    }
}
