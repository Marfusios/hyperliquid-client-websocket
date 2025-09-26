﻿using Hyperliquid.Client.Websocket.Messages;
using Hyperliquid.Client.Websocket.Utils;
using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests
{
    /// <summary>
    /// Authentication request, call before accessing any private API
    /// </summary>
    public class AuthenticationRequest : RequestBase
    {
        /// <summary>
        /// Authentication request
        /// </summary>
        /// <param name="apiKey">Your API key</param>
        /// <param name="apiSecret">Your API secret</param>
        public AuthenticationRequest(string apiKey, string apiSecret) : this(apiKey, apiSecret, false)
        {
        }

        /// <summary>
        /// Authentication request
        /// </summary>
        /// <param name="apiKey">Your API key</param>
        /// <param name="apiSecret">Your API secret</param>
        /// <param name="deadManSwitchEnabled">Dead-Man-Switch flag (optional), when socket is closed, cancel all account orders</param>
        public AuthenticationRequest(string apiKey, string apiSecret, bool deadManSwitchEnabled)
        {
            BfxValidations.ValidateInput(apiKey, nameof(apiKey));
            BfxValidations.ValidateInput(apiSecret, nameof(apiSecret));

            ApiKey = apiKey;

            AuthNonce = BitfinexAuthentication.CreateAuthNonce();
            AuthPayload = BitfinexAuthentication.CreateAuthPayload(AuthNonce);

            AuthSig = BitfinexAuthentication.CreateSignature(AuthPayload, apiSecret);

            if (deadManSwitchEnabled)
                Dms = 4;
        }

        /// <inheritdoc />
        public override MessageType EventType => MessageType.Auth;

        /// <summary>
        /// Your API key
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// The generated signature
        /// </summary>
        public string AuthSig { get; }

        /// <summary>
        /// An ever increasing numeric string but should not exceed the MAX_SAFE_INTEGER constant value of 9007199254740991.
        /// </summary>
        public long AuthNonce { get; }

        /// <summary>
        /// Computed authentication payload
        /// </summary>
        public string AuthPayload { get; }

        /// <summary>
        /// Dead-Man-Switch flag (optional, value 4), when socket is closed, cancel all account orders
        /// </summary>
        public int? Dms { get; }

        
    }
}
