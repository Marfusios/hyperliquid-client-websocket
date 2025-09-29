using Newtonsoft.Json;
using System;
using Hyperliquid.Client.Websocket.Json;
using Hyperliquid.Client.Websocket.Enums;

namespace Hyperliquid.Client.Websocket.Responses.Orders
{
    /// <summary>
    /// User order update response
    /// </summary>
    public class UserOrderResponse
    {
        /// <summary>
        /// Order information
        /// </summary>
        [JsonProperty("order")]
        public BasicOrder Order { get; set; } = new BasicOrder();

        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus Status { get; set; } = OrderStatus.Unknown;

        /// <summary>
        /// Status timestamp
        /// </summary>
        [JsonProperty("statusTimestamp")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime StatusTimestamp { get; set; }
    }
}