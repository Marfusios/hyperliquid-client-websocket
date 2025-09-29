using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Hyperliquid.Client.Websocket.Responses.Hyperliquid;

namespace Hyperliquid.Client.Websocket.Client
{
    /// <summary>
    /// Handler for Hyperliquid websocket messages
    /// </summary>
    internal class HyperliquidMessageHandler
    {
        private readonly HyperliquidClientStreams _streams;
        private readonly ILogger _logger;

        public HyperliquidMessageHandler(HyperliquidClientStreams streams, ILogger logger)
        {
            _streams = streams;
            _logger = logger;
        }

        public void HandleMessage(string message)
        {
            try
            {
                var json = JObject.Parse(message);
                var channel = json["channel"]?.ToString();

                if (string.IsNullOrEmpty(channel))
                {
                    _logger.LogWarning("Received message without channel: {message}", message);
                    return;
                }

                if (channel == "pong")
                {
                    HandlePong();
                    return;
                }

                var data = json["data"];
                if (data == null)
                {
                    _logger.LogWarning("Received message without data: {message}", message);
                    return;
                }

                switch (channel)
                {
                    case "subscriptionResponse":
                        HandleSubscriptionResponse(data);
                        break;
                    case "allMids":
                        HandleAllMids(data);
                        break;
                    case "notification":
                        HandleNotification(data);
                        break;
                    case "l2Book":
                        HandleL2Book(data);
                        break;
                    case "trades":
                        HandleTrades(data);
                        break;
                    case "orderUpdates":
                        HandleOrderUpdates(data);
                        break;
                    case "userFills":
                        HandleUserFills(data);
                        break;
                    default:
                        _logger.LogDebug("Unhandled channel: {channel}", channel);
                        break;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception while handling message: {message}", message);
            }
        }

        private void HandleSubscriptionResponse(JToken data)
        {
            try
            {
                var response = data.ToObject<SubscriptionResponseData>();
                if (response != null)
                {
                    _streams.SubscriptionResponseSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling subscription response");
            }
        }

        private void HandlePong()
        {
            try
            {
                _streams.PongSubject.OnNext(new PongResponse());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling ping-pong data");
            }
        }

        private void HandleAllMids(JToken data)
        {
            try
            {
                var response = data.ToObject<AllMidsResponse>();
                if (response != null)
                {
                    _streams.AllMidsSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling all mids data");
            }
        }

        private void HandleNotification(JToken data)
        {
            try
            {
                var response = data.ToObject<HyperliquidNotificationResponse>();
                if (response != null)
                {
                    _streams.NotificationSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling notification data");
            }
        }

        private void HandleL2Book(JToken data)
        {
            try
            {
                var response = data.ToObject<WsBookResponse>();
                if (response != null)
                {
                    _streams.L2BookSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling L2 book data");
            }
        }

        private void HandleTrades(JToken data)
        {
            try
            {
                var response = data.ToObject<WsTradeResponse[]>();
                if (response != null)
                {
                    _streams.TradesSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling trades data");
            }
        }

        private void HandleOrderUpdates(JToken data)
        {
            try
            {
                var response = data.ToObject<WsOrderResponse[]>();
                if (response != null)
                {
                    _streams.OrderUpdatesSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling order updates data");
            }
        }

        private void HandleUserFills(JToken data)
        {
            try
            {
                var response = data.ToObject<WsUserFillsResponse>();
                if (response != null)
                {
                    _streams.UserFillsSubject.OnNext(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error handling user fills data");
            }
        }
    }
}