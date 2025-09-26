using System;

namespace Hyperliquid.Client.Websocket
{
    /// <summary>
    /// Static values
    /// </summary>
    public static class HyperliquidValues
    {
        /// <summary>
        /// Url to Hyperliquid mainnet websocket API
        /// </summary>
        public static readonly Uri MainnetWebsocketApiUrl = new Uri("wss://api.hyperliquid.xyz/ws");

        /// <summary>
        /// Url to Hyperliquid testnet websocket API
        /// </summary>
        public static readonly Uri TestnetWebsocketApiUrl = new Uri("wss://api.hyperliquid-testnet.xyz/ws");
    }
}
