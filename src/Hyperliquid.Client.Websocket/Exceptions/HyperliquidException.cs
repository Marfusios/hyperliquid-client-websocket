using System;

namespace Hyperliquid.Client.Websocket.Exceptions
{
    public class HyperliquidException : Exception
    {
        public HyperliquidException()
        {
        }

        public HyperliquidException(string message)
            : base(message)
        {
        }

        public HyperliquidException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
