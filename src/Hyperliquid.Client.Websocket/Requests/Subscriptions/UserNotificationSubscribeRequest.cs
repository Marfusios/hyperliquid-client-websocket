using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Subscriptions
{
    /// <summary>
    /// Subscribe to notifications for a specific user
    /// </summary>
    public class UserNotificationSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for notification subscription
        /// </summary>
        /// <param name="user">User address</param>
        public UserNotificationSubscribeRequest(string user)
        {
            HlValidations.ValidateInput(user, nameof(user));

            _subscription = new
            {
                type = "notification",
                user = user
            };
        }

        private readonly object _subscription;

        /// <inheritdoc />
        public override object Subscription => _subscription;
    }
}