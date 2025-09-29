using System;

namespace Hyperliquid.Client.Websocket.Exceptions
{
    public class HyperliquidBadInputException : HyperliquidException
    {
        public HyperliquidBadInputException()
        {
        }

        public HyperliquidBadInputException(string message) : base(message)
        {
        }

        public HyperliquidBadInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
