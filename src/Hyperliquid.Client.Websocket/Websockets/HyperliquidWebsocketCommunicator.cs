using System;
using System.Net.WebSockets;
using Hyperliquid.Client.Websocket.Communicator;
using Microsoft.Extensions.Logging;
using Websocket.Client;

namespace Hyperliquid.Client.Websocket.Websockets
{
    /// <inheritdoc cref="WebsocketClient" />
    public class HyperliquidWebsocketCommunicator : WebsocketClient, IHyperliquidCommunicator
    {
        /// <inheritdoc />
        public HyperliquidWebsocketCommunicator(Uri url, Func<ClientWebSocket>? clientFactory = null)
            : base(url, clientFactory)
        {
        }

        /// <inheritdoc />
        public HyperliquidWebsocketCommunicator(Uri url, ILogger<HyperliquidWebsocketCommunicator> logger, Func<ClientWebSocket>? clientFactory = null)
            : base(url, logger, clientFactory)
        {
        }
    }
}