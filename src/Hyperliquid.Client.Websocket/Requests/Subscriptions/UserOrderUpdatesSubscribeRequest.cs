using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    /// <summary>
    /// Subscribe to order updates for a specific user
    /// </summary>
    public class UserOrderUpdatesSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for order updates subscription
        /// </summary>
        /// <param name="user">User address</param>
        public UserOrderUpdatesSubscribeRequest(string user)
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