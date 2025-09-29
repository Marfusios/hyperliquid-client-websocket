using System;
using Hyperliquid.Client.Websocket.Enums;
using Hyperliquid.Client.Websocket.Utils;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Json
{
    /// <summary>
    /// JSON converter for OrderStatus enum that handles string values
    /// </summary>
    public class OrderStatusConverter : JsonConverter<OrderStatus>
    {
        public override void WriteJson(JsonWriter writer, OrderStatus value, JsonSerializer serializer)
        {
            if (value == OrderStatus.Unknown)
            {
                writer.WriteValue((string?)null);
                return;
            }

            try
            {
                var stringValue = value.GetStringValue();
                writer.WriteValue(stringValue);
            }
            catch
            {
                writer.WriteValue((string?)null);
            }
        }

        public override OrderStatus ReadJson(JsonReader reader, Type objectType, OrderStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();
            
            if (string.IsNullOrEmpty(value))
                return OrderStatus.Unknown;

            // Try to find the enum value by its StringValue attribute
            var orderStatus = default(OrderStatus).GetFieldByStringValue(value);
            
            if (!orderStatus.Equals(default(OrderStatus)))
                return orderStatus;

            // If not found, return Unknown
            return OrderStatus.Unknown;
        }
    }
}