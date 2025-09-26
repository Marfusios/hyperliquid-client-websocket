using Hyperliquid.Client.Websocket.Communicator;

namespace Hyperliquid.Client.Websocket.Client
{
    internal static class BitfinexLogger
    {
        public static string L(string msg, IBitfinexCommunicator communicator)
        {
            return $"[{communicator.Name ?? "BFX"} WEBSOCKET CLIENT] {msg}";
        }
    }
}
