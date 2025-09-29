using System;
using System.Diagnostics;
using Hyperliquid.Client.Websocket.Json;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Books
{
    /// <summary>
    /// Order book response
    /// </summary>
    [DebuggerDisplay("Book Response {Coin} {Levels[0].Length} | {Levels[1].Length}")]
    public class BookResponse
    {
        /// <summary>
        /// Coin symbol
        /// </summary>
        [JsonProperty("coin")]
        public string Coin { get; set; } = string.Empty;

        /// <summary>
        /// Order book levels [bids, asks]
        /// </summary>
        [JsonProperty("levels")]
        public Level[][] Levels { get; set; } = new Level[2][];

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
        public DateTime Time { get; set; }
    }
}