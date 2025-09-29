using Hyperliquid.Client.Websocket.Requests.Hyperliquid;
using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Hyperliquid.Subscriptions
{
    /// <summary>
    /// Subscribe to order updates for a specific user
    /// </summary>
    public class OrderUpdatesSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for order updates subscription
        /// </summary>
        /// <param name="user">User address</param>
        public OrderUpdatesSubscribeRequest(string user)
        {
            HlValidations.ValidateInput(user, nameof(user));
            
            _subscription = new
            {
                type = "orderUpdates",
                user = user
            };
        }

        private readonly object _subscription;

        /// <inheritdoc />
        public override object Subscription => _subscription;
    }
}