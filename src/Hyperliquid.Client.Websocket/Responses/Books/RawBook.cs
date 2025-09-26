﻿using System.Reactive.Subjects;
using Hyperliquid.Client.Websocket.Responses.Configurations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hyperliquid.Client.Websocket.Responses.Books
{
    /// <summary>
    /// The state of the Bitfinex order book (raw - every single order)
    /// </summary>
    [JsonConverter(typeof(RawBookConverter))]
    public class RawBook : ResponseBase
    {
        /// <summary>
        /// Identification number of the order
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// Identification number of the funding offer
        /// </summary>
        public long OfferId { get; set; }

        /// <summary>
        /// Order price; if 0 you have to remove the order from your book
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Amount of order
        /// Trading: if AMOUNT greater than 0 then bid else ask; 
        /// Funding: if AMOUNT lower than 0 then bid else ask;
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Funding rate for the offer; if 0 you have to remove the offer from your book
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Funding period in days
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Target pair
        /// </summary>
        [JsonIgnore]
        public string Pair { get; set; }

        
        /// <summary>
        /// Target symbol
        /// </summary>
        [JsonIgnore]
        public string Symbol { get; set; }


        internal static void Handle(JToken token, SubscribedResponse subscription, ConfigurationState config, 
            Subject<RawBook> subject, Subject<RawBook[]> subjectSnapshot, Subject<ChecksumResponse> subjectChecksum)
        {
            var data = token[1];

            if (config.IsChecksumEnabled)
            {
                if (data?.Type == JTokenType.String && data.Value<string>() == "cs")
                {
                    ChecksumResponse.Handle(token, subscription, config, subjectChecksum);
                    return;
                }
            }
            
            if (data?.Type != JTokenType.Array)
            {
                return; // heartbeat, ignore
            }

            if(data.First?.Type == JTokenType.Array)
            {
                // initial snapshot
                Handle(token, data.ToObject<RawBook[]>(), subscription, config, subject, subjectSnapshot);
                return;
            }

            var book = data.ToObject<RawBook>();
            book.Pair = subscription.Pair;
            book.Symbol = subscription.Symbol;
            book.ChanId = subscription.ChanId;
            SetGlobalData(book, config, token);
            subject.OnNext(book);
        }

        internal static void Handle(JToken token, RawBook[] books, SubscribedResponse subscription, ConfigurationState config, 
            Subject<RawBook> subject, Subject<RawBook[]> subjectSnapshot)
        {
            foreach (var book in books)
            {
                book.Pair = subscription.Pair;
                book.Symbol = subscription.Symbol;
                book.ChanId = subscription.ChanId;
                SetGlobalData(book, config, token);

                // raise as normal book stream
                subject.OnNext(book);
            }

            // raise as snapshot book stream
            subjectSnapshot.OnNext(books);
        }
    }
}
