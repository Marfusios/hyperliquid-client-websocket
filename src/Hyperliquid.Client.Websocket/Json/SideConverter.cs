using System;
using Hyperliquid.Client.Websocket.Enums;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Json
{
    /// <summary>
    /// JSON converter for Side enum that handles 'B'/'A' string values
    /// </summary>
    public class SideConverter : JsonConverter<Side>
    {
        public override void WriteJson(JsonWriter writer, Side value, JsonSerializer serializer)
        {
            switch (value)
            {
                case Side.Bid:
                    writer.WriteValue("B");
                    break;
                case Side.Ask:
                    writer.WriteValue("A");
                    break;
                case Side.Unknown:
                default:
                    writer.WriteValue((string?)null);
                    break;
            }
        }

        public override Side ReadJson(JsonReader reader, Type objectType, Side existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();
            if (value == "B")
                return Side.Bid;
            if (value == "A")
                return Side.Ask;
            if (string.IsNullOrEmpty(value))
                return Side.Unknown;
            
            throw new JsonSerializationException($"Invalid Side value: {value}");
        }
    }
}