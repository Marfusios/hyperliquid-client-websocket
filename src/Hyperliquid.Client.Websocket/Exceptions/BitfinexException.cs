using System;

namespace Hyperliquid.Client.Websocket.Exceptions
{
    public class BitfinexException : Exception
    {
        public BitfinexException()
        {
        }

        public BitfinexException(string message)
            : base(message)
        {
        }

        public BitfinexException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
