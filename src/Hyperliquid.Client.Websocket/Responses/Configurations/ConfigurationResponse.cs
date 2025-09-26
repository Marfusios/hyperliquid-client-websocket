using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Messages;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses.Configurations
{
    /// <summary>
    /// Info about processed configuration
    /// </summary>
    public class ConfigurationResponse : MessageBase
    {
        /// <summary>
        /// Returns OK if Bitfinex accepted your configuration request
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Returns configured flags, see `ConfigurationFlag` enum
        /// </summary>
        public int? Flags { get; set; }

        /// <summary>
        /// True if configuration happened successfully
        /// </summary>
        [JsonIgnore] 
        public bool IsConfigured => Status == "OK" && Flags.HasValue;


        internal static void Handle(string msg, Subject<ConfigurationResponse> subject)
        {
            var response = BitfinexSerialization.Deserialize<ConfigurationResponse>(msg);
            subject.OnNext(response);
        }
    }
}
