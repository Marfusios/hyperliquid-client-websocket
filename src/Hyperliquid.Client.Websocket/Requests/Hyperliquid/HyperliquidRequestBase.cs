using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Requests.Hyperliquid
{
    /// <summary>
    /// Base class for every Hyperliquid request
    /// </summary>
    public abstract class HyperliquidRequestBase
    {
        /// <summary>
        /// Request method
        /// </summary>
        [JsonProperty("method")]
        public virtual string Method { get; } = "subscribe";

        /// <summary>
        /// Subscription details
        /// </summary>
        [JsonProperty("subscription")]
        public abstract object? Subscription { get; }
    }
}