using Hyperliquid.Client.Websocket.Requests.Hyperliquid;
using Hyperliquid.Client.Websocket.Validations;

namespace Hyperliquid.Client.Websocket.Requests.Hyperliquid.Subscriptions
{
    /// <summary>
    /// Subscribe to user fills for a specific user
    /// </summary>
    public class UserFillsSubscribeRequest : HyperliquidRequestBase
    {
        /// <summary>
        /// Initialize request for user fills subscription
        /// </summary>
        /// <param name="user">User address</param>
        /// <param name="aggregateByTime">Whether to aggregate by time (optional)</param>
        public UserFillsSubscribeRequest(string user, bool? aggregateByTime = null)
        {
            HlValidations.ValidateInput(user, nameof(user));

            if (aggregateByTime.HasValue)
            {
                _subscription = new
                {
                    type = "userFills",
                    user = user,
                    aggregateByTime = aggregateByTime.Value
                };
            }
            else
            {
                _subscription = new
                {
                    type = "userFills",
                    user = user
                };
            }
        }

        private readonly object _subscription;

        /// <inheritdoc />
        public override object Subscription => _subscription;
    }
}