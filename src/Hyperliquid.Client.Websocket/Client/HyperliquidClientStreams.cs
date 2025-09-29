using System;
using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Responses.Hyperliquid;

namespace Hyperliquid.Client.Websocket.Client
{
    /// <summary>
    /// All provided streams from Hyperliquid websocket API.
    /// You need to subscribe first, send subscription request (for example: `client.Send(new AllMidsSubscribeRequest())`)
    /// </summary>
    public class HyperliquidClientStreams
    {
        internal readonly Subject<PongResponse> PongSubject = new Subject<PongResponse>();
        internal readonly Subject<AllMidsResponse> AllMidsSubject = new Subject<AllMidsResponse>();
        internal readonly Subject<HyperliquidNotificationResponse> NotificationSubject = new Subject<HyperliquidNotificationResponse>();
        internal readonly Subject<WsBookResponse> L2BookSubject = new Subject<WsBookResponse>();
        internal readonly Subject<WsTradeResponse[]> TradesSubject = new Subject<WsTradeResponse[]>();
        internal readonly Subject<WsOrderResponse[]> OrderUpdatesSubject = new Subject<WsOrderResponse[]>();
        internal readonly Subject<WsUserFillsResponse> UserFillsSubject = new Subject<WsUserFillsResponse>();
        internal readonly Subject<SubscriptionResponseData> SubscriptionResponseSubject = new Subject<SubscriptionResponseData>();

        /// <summary>
        /// Ping-Pong stream
        /// </summary>
        public IObservable<PongResponse> PongStream => PongSubject;

        /// <summary>
        /// All mid prices stream
        /// </summary>
        public IObservable<AllMidsResponse> AllMidsStream => AllMidsSubject;

        /// <summary>
        /// Notification stream for subscribed user
        /// </summary>
        public IObservable<HyperliquidNotificationResponse> NotificationStream => NotificationSubject;

        /// <summary>
        /// L2 order book stream for subscribed coin
        /// </summary>
        public IObservable<WsBookResponse> L2BookStream => L2BookSubject;

        /// <summary>
        /// Trades stream for subscribed coin
        /// </summary>
        public IObservable<WsTradeResponse[]> TradesStream => TradesSubject;

        /// <summary>
        /// Order updates stream for subscribed user
        /// </summary>
        public IObservable<WsOrderResponse[]> OrderUpdatesStream => OrderUpdatesSubject;

        /// <summary>
        /// User fills stream for subscribed user
        /// </summary>
        public IObservable<WsUserFillsResponse> UserFillsStream => UserFillsSubject;

        /// <summary>
        /// Subscription response stream
        /// </summary>
        public IObservable<SubscriptionResponseData> SubscriptionResponseStream => SubscriptionResponseSubject;

        internal HyperliquidClientStreams()
        {
        }
    }
}