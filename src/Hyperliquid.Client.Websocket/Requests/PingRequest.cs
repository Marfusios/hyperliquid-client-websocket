using Hyperliquid.Client.Websocket.Messages;

namespace Hyperliquid.Client.Websocket.Requests
{
    public class PingRequest : RequestBase
    {
        public override MessageType EventType => MessageType.Ping;
        public int Cid { get; set; } = 33;
    }
}
