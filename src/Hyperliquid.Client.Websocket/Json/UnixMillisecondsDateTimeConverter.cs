using System;
using System.Globalization;
using Hyperliquid.Client.Websocket.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hyperliquid.Client.Websocket.Json
{
    /// <inheritdoc />
    public class UnixMillisecondsDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subtracted = ((DateTime)value).Subtract(HyperliquidTime.UnixBase);
            writer.WriteRawValue(subtracted.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return HyperliquidTime.ConvertToTime((long)reader.Value);
        }
    }
}
