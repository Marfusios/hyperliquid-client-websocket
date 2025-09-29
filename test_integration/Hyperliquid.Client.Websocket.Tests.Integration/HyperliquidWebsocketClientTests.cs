using System;
using System.Threading;
using System.Threading.Tasks;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Requests.Hyperliquid.Subscriptions;
using Hyperliquid.Client.Websocket.Responses.Hyperliquid;
using Hyperliquid.Client.Websocket.Websockets;
using Xunit;

namespace Hyperliquid.Client.Websocket.Tests.Integration
{
    public class HyperliquidWebsocketClientTests
    {
        [Fact]
        public async Task PingPong()
        {
            var url = HyperliquidValues.MainnetWebsocketApiUrl;
            using var communicator = new HyperliquidWebsocketCommunicator(url);
            PongResponse received = null;
            var receivedEvent = new ManualResetEvent(false);

            using var client = new HyperliquidWebsocketClient(communicator);
            client.Streams.PongStream.Subscribe(pong =>
            {
                received = pong;
                receivedEvent.Set();
            });

            await communicator.Start();

            client.Send(new PingRequest());

            receivedEvent.WaitOne(TimeSpan.FromSeconds(30));

            Assert.NotNull(received);
        }
    }
}
