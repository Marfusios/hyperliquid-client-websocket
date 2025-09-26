using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Files;
using Hyperliquid.Client.Websocket.Responses.Trades;
using Xunit;

namespace Hyperliquid.Client.Websocket.Tests.Integration
{
    public class BitfinexFileCommunicatorTests
    {
        // ----------------------------------------------------------------
        // Don't forget to decompress gzip files before starting the tests
        // ----------------------------------------------------------------

        [SkippableFact()]
        public async Task OnStart_ShouldStreamMessagesFromFile()
        {
            var files = new[]
            {
                "data/bitfinex_raw_2018-11-12.txt"
            };
            foreach (var file in files)
            {
                var exist = File.Exists(file);
                Skip.If(!exist, $"The file '{file}' doesn't exist. Don't forget to decompress gzip file!");
            }

            var trades = new List<Trade>();

            var communicator = new BitfinexFileCommunicator();
            communicator.FileNames = files;
            communicator.Delimiter = ";;";

            var client = new BitfinexWebsocketClient(communicator);
            client.Streams.TradesStream.Subscribe(trade =>
            {
                trades.Add(trade);
            });

            await communicator.Start();

            Assert.Equal(8938, trades.Count);
        }
    }
}
