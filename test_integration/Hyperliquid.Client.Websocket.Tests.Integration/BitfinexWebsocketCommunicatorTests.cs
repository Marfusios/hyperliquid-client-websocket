using System;
using System.Threading;
using System.Threading.Tasks;
using Hyperliquid.Client.Websocket.Websockets;
using Xunit;

namespace Hyperliquid.Client.Websocket.Tests.Integration
{
    public class BitfinexWebsocketCommunicatorTests
    {
        [Fact]
        public async Task OnStarting_ShouldGetInfoResponse()
        {
            var url = HyperliquidValues.MainnetWebsocketApiUrl;
            using (var communicator = new BitfinexWebsocketCommunicator(url))
            {
                string received = null;
                var receivedEvent = new ManualResetEvent(false);

                communicator.MessageReceived.Subscribe(msg =>
                {
                    received = msg.Text;
                    receivedEvent.Set();
                });

                await communicator.Start();

                receivedEvent.WaitOne(TimeSpan.FromSeconds(30));

                Assert.NotNull(received);
                Assert.Contains("\"event\":\"info\",\"version\":2", received);
            }
        }
    }
}
