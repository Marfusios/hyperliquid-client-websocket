using System;
using Hyperliquid.Client.Websocket.Communicator;
using Hyperliquid.Client.Websocket.Json;
using Hyperliquid.Client.Websocket.Validations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Websocket.Client;

namespace Hyperliquid.Client.Websocket.Client
{
    /// <summary>
    /// Hyperliquid websocket client, it wraps `IHyperliquidCommunicator` and parse raw data into streams.
    /// Send subscription requests (for example: `new AllMidsSubscribeRequest()`) and subscribe to `Streams`
    /// </summary>
    public class HyperliquidWebsocketClient : IDisposable
    {
        private readonly ILogger _logger;
        private readonly IHyperliquidCommunicator _communicator;
        private readonly IDisposable _messageReceivedSubscription;
        private readonly HyperliquidMessageHandler _messageHandler;

        /// <inheritdoc />
        public HyperliquidWebsocketClient(IHyperliquidCommunicator communicator, ILogger? logger = null)
        {
            HlValidations.ValidateInput(communicator, nameof(communicator));

            _communicator = communicator;
            _logger = logger ?? NullLogger<HyperliquidWebsocketClient>.Instance;
            _messageHandler = new HyperliquidMessageHandler(Streams, _logger);
            _messageReceivedSubscription = _communicator.MessageReceived.Subscribe(HandleMessage);
        }

        /// <summary>
        /// Provided message streams
        /// </summary>
        public HyperliquidClientStreams Streams { get; } = new HyperliquidClientStreams();

        /// <summary>
        /// Expose logger for this client
        /// </summary>
        public ILogger Logger => _logger;

        /// <summary>
        /// Cleanup everything
        /// </summary>
        public void Dispose()
        {
            _messageReceivedSubscription?.Dispose();
        }

        /// <summary>
        /// Serializes request and sends message via websocket communicator. 
        /// It logs and re-throws every exception. 
        /// </summary>
        /// <param name="request">Request/message to be sent</param>
        public void Send<T>(T request)
        {
            try
            {
                HlValidations.ValidateInput(request, nameof(request));

                var serialized = JsonConvert.SerializeObject(request, HyperliquidJsonSerializer.Settings);
                _communicator.Send(serialized);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception while sending message '{request}'. Error: {error}", request, e.Message);
                throw;
            }
        }

        private void HandleMessage(ResponseMessage message)
        {
            try
            {
                var formatted = (message.Text ?? string.Empty).Trim();

                if (string.IsNullOrEmpty(formatted))
                {
                    return;
                }

                _messageHandler.HandleMessage(formatted);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception while receiving message, error: {error}", e.Message);
            }
        }
    }
}