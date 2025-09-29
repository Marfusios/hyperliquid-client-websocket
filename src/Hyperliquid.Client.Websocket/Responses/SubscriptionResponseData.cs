using Hyperliquid.Client.Websocket.Json;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses
{
    /// <summary>
    /// Subscription response
    /// </summary>
    public class SubscriptionResponseData
    {
        /// <summary>
        /// Method name
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; } = string.Empty;

        /// <summary>
        /// Original subscription data
        /// </summary>
        [JsonProperty("subscription")]
        public object Subscription { get; set; } = new object();

        /// <summary>
        /// Serialized Subscription data
        /// </summary>
        public string SubscriptionString =>
            JsonConvert.SerializeObject(Subscription, HyperliquidJsonSerializer.Settings);
    }
}