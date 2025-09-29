using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Files;
using Hyperliquid.Client.Websocket.Responses;
using Xunit;

namespace Hyperliquid.Client.Websocket.Tests.Integration
{
    public class HyperliquidFileCommunicatorTests
    {
        // ----------------------------------------------------------------
        // Don't forget to decompress gzip files before starting the tests
        // ----------------------------------------------------------------

        [SkippableFact()]
        public async Task OnStart_ShouldStreamMessagesFromFile()
        {
            var files = new[]
            {
                "data/Hyperliquid_raw_2015-09-29.txt"
            };
            foreach (var file in files)
            {
                var exist = File.Exists(file);
                Skip.If(!exist, $"The file '{file}' doesn't exist. Don't forget to decompress gzip file!");
            }

            var trades = new List<TradeResponse>();

            var communicator = new HyperliquidFileCommunicator();
            communicator.FileNames = files;
            communicator.Delimiter = ";;";

            var client = new HyperliquidWebsocketClient(communicator);
            client.Streams.TradesStream.Subscribe(trade =>
            {
                trades.AddRange(trade);
            });

            await communicator.Start();

            Assert.Equal(8938, trades.Count);
        }
    }
}
