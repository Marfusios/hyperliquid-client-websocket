using Hyperliquid.Client.Websocket.Client;
using Hyperliquid.Client.Websocket.Websockets;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using Hyperliquid.Client.Websocket.Requests.Subscriptions;

namespace Hyperliquid.Client.Websocket.Sample
{
    class Program
    {
        private static readonly ManualResetEvent _exitEvent = new(false);

        private const string UserAddress = "0x1234567890123456789012345678901234567890"; // Replace with actual user address

        static void Main(string[] args)
        {
            var logger = InitLogging();

            AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;
            AssemblyLoadContext.Default.Unloading += DefaultOnUnloading;
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;

            Console.WriteLine("|=======================---|");
            Console.WriteLine("|    HYPERLIQUID CLIENT    |");
            Console.WriteLine("|=======================---|");
            Console.WriteLine();

            Log.Debug("====================================");
            Log.Debug("              STARTING              ");
            Log.Debug("====================================");


            RunHyperliquidClient(logger);


            Log.Debug("====================================");
            Log.Debug("              STOPPING              ");
            Log.Debug("====================================");
            Log.CloseAndFlush();
        }

        private static void RunHyperliquidClient(SerilogLoggerFactory logger)
        {
            var url = HyperliquidValues.MainnetWebsocketApiUrl;
            using var communicator = new HyperliquidWebsocketCommunicator(url, logger.CreateLogger<HyperliquidWebsocketCommunicator>());
            communicator.Name = "Hyperliquid-1";
            communicator.ReconnectTimeout = TimeSpan.FromSeconds(30);
            communicator.ReconnectionHappened.Subscribe(info =>
                Log.Information("Reconnection happened, type: {type}", info.Type));

            using var client = new HyperliquidWebsocketClient(communicator, logger.CreateLogger<HyperliquidWebsocketClient>());
            SubscribeToHyperliquidStreams(client);
            SendHyperliquidSubscriptionRequests(client);

            communicator.Start();

            _exitEvent.WaitOne();
        }

        private static void SendHyperliquidSubscriptionRequests(HyperliquidWebsocketClient client)
        {
            Log.Information("Sending Hyperliquid subscription requests...");

            // Subscribe to all mids
            client.Send(new AllMidsSubscribeRequest());

            // Subscribe to L2 book for BTC
            client.Send(new L2BookSubscribeRequest("BTC"));

            // Subscribe to trades for BTC
            client.Send(new TradesSubscribeRequest("BTC"));

            // Subscribe to notifications (requires user address)
            if (!string.IsNullOrEmpty(UserAddress) && UserAddress != "0x1234567890123456789012345678901234567890")
            {
                client.Send(new UserNotificationSubscribeRequest(UserAddress));
                client.Send(new UserOrderUpdatesSubscribeRequest(UserAddress));
                client.Send(new UserFillsSubscribeRequest(UserAddress));
            }
        }

        private static void SubscribeToHyperliquidStreams(HyperliquidWebsocketClient client)
        {
            Log.Information("Setting up Hyperliquid stream subscriptions...");

            client.Streams.SubscriptionResponseStream.Subscribe(response =>
                Log.Information("Subscription response: {subscription}", response.SubscriptionString));

            client.Streams.AllMidsStream.Subscribe(mids =>
            {
                var midsCount = mids.MidPrices.Count;
                Log.Information("All mids received: {count} pairs. BTC: {btcPrice}", midsCount, mids.MidPrices["BTC"]);
            });

            client.Streams.UserNotificationStream.Subscribe(notification =>
                Log.Information("Notification: {message}", notification.Notification));

            client.Streams.L2BookStream.Subscribe(book =>
            {
                var bids = book.Levels[0];
                var asks = book.Levels[1];
                Log.Information("L2 Book {coin} [{bids}/{asks}] - Bid: {bid}, Ask: {ask}, Time: {time}",
                    book.Coin, bids.Length, asks.Length, bids[0].Price, asks[0].Price, book.Time.ToString("HH:mm:ss.fff"));
            });

            client.Streams.TradesStream.Subscribe(trades =>
            {
                Log.Information("Trades received: {count} trades", trades?.Length ?? 0);
                foreach (var trade in trades ?? [])
                {
                    Log.Information("  Trade {coin}: {side} {size} @ {price} (TID: {tid}), Time: {time}",
                        trade.Coin, trade.Side, trade.Size, trade.Price, trade.TradeId, trade.Time.ToString("HH:mm:ss.fff"));
                }
            });

            client.Streams.UserOrderUpdatesStream.Subscribe(orders =>
            {
                Log.Information("Order updates received: {count} orders", orders?.Length ?? 0);
                foreach (var order in orders ?? [])
                {
                    Log.Information("  Order {coin}: {side} {size} @ {price} - Status: {status}, Time: {time}",
                        order.Order.Coin, order.Order.Side, order.Order.Size, order.Order.LimitPrice, order.Status, order.StatusTimestamp.ToString("HH:mm:ss.fff"));
                }
            });

            client.Streams.UserFillsStream.Subscribe(fills =>
            {
                var isSnapshot = fills.IsSnapshot == true ? " (snapshot)" : "";
                Log.Information("User fills received{snapshot}: {count} fills for user {user}",
                    isSnapshot, fills.Fills.Length, fills.User);
                foreach (var fill in fills.Fills.Reverse().Take(10))
                {
                    Log.Information("  Fill {coin}: {side} {size} @ {price} - Fee: {fee}, Time: {time}",
                        fill.Coin, fill.Side, fill.Size, fill.Price, fill.Fee, fill.Time);
                }
            });
        }

        private static SerilogLoggerFactory InitLogging()
        {
            var executingDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var logPath = Path.Combine(executingDir, "logs", "verbose.log");
            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .WriteTo.Console(LogEventLevel.Debug, outputTemplate:
                    "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            Log.Logger = logger;
            return new SerilogLoggerFactory(logger);
        }

        private static void CurrentDomainOnProcessExit(object sender, EventArgs eventArgs)
        {
            Log.Warning("Exiting process");
            _exitEvent.Set();
        }

        private static void DefaultOnUnloading(AssemblyLoadContext assemblyLoadContext)
        {
            Log.Warning("Unloading process");
            _exitEvent.Set();
        }

        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Log.Warning("Canceling process");
            e.Cancel = true;
            _exitEvent.Set();
        }
    }
}
