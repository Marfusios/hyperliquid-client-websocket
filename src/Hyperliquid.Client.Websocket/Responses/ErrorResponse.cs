using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Messages;

namespace Hyperliquid.Client.Websocket.Responses
{
    public class ErrorResponse : MessageBase
    {
        public string Code { get; set; }
        public string Msg { get; set; }


        internal static void Handle(string msg, Subject<ErrorResponse> subject)
        {
            var error = BitfinexSerialization.Deserialize<ErrorResponse>(msg);
            if (error != null)
                subject.OnNext(error);
        }
    }
}
