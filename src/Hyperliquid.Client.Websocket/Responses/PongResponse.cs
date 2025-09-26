using System;
using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Json;
using Hyperliquid.Client.Websocket.Messages;
using Newtonsoft.Json;

namespace Hyperliquid.Client.Websocket.Responses
{
    public class PongResponse : MessageBase
    {
        public int Cid { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Ts { get; set; }


        internal static void Handle(string msg, Subject<PongResponse> subject)
        {
            var pong = BitfinexSerialization.Deserialize<PongResponse>(msg);
            subject.OnNext(pong);
        }
    }
}
