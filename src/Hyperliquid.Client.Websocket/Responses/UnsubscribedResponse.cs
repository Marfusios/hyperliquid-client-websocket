using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Messages;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses
{
    /// <summary>
    /// Information about unsubscription
    /// </summary>
    public class UnsubscribedResponse : MessageBase
    {
        /// <summary>
        /// Unique channel id, you need to store this value in order to future unsubscription
        /// </summary>
        public int ChanId { get; set; }

        /// <summary>
        /// Unsubscription status
        /// </summary>
        public string Status {get; set; }

        /// <summary>
        /// True if unsubscription success
        /// </summary>
        [JsonIgnore] 
        public bool IsUnsubscribed => Status == "OK";


        internal static void Handle(string msg, Subject<UnsubscribedResponse> subject)
        {
            var response = BitfinexSerialization.Deserialize<UnsubscribedResponse>(msg);
            subject.OnNext(response);
        }
    }
}
