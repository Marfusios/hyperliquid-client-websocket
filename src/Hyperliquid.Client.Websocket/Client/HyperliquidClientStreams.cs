using System;
using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Responses;
using Hyperliquid.Client.Websocket.Responses.Books;
using Hyperliquid.Client.Websocket.Responses.Fills;
using Hyperliquid.Client.Websocket.Responses.Orders;

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
        internal readonly Subject<BookResponse> L2BookSubject = new Subject<BookResponse>();
        internal readonly Subject<TradeResponse[]> TradesSubject = new Subject<TradeResponse[]>();

        internal readonly Subject<UserNotificationResponse> UserNotificationSubject = new Subject<UserNotificationResponse>();
        internal readonly Subject<UserOrderResponse[]> UserOrderUpdatesSubject = new Subject<UserOrderResponse[]>();
        internal readonly Subject<UserFillsResponse> UserFillsSubject = new Subject<UserFillsResponse>();

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
        /// L2 order book stream for subscribed coin
        /// </summary>
        public IObservable<BookResponse> L2BookStream => L2BookSubject;

        /// <summary>
        /// Trades stream for subscribed coin
        /// </summary>
        public IObservable<TradeResponse[]> TradesStream => TradesSubject;

        /// <summary>
        /// Notification stream for subscribed user
        /// </summary>
        public IObservable<UserNotificationResponse> UserNotificationStream => UserNotificationSubject;

        /// <summary>
        /// Order updates stream for subscribed user
        /// </summary>
        public IObservable<UserOrderResponse[]> UserOrderUpdatesStream => UserOrderUpdatesSubject;

        /// <summary>
        /// User fills stream for subscribed user
        /// </summary>
        public IObservable<UserFillsResponse> UserFillsStream => UserFillsSubject;

        /// <summary>
        /// Subscription response stream
        /// </summary>
        public IObservable<SubscriptionResponseData> SubscriptionResponseStream => SubscriptionResponseSubject;

        internal HyperliquidClientStreams()
        {
        }
    }
}