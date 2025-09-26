using System;
using System.Collections.Generic;
using Hyperliquid.Client.Websocket.Responses.Configurations;
using Newtonsoft.Json.Linq;

namespace Hyperliquid.Client.Websocket.Client
{
    internal class BitfinexChannelList :  Dictionary<int, Action<JToken, ConfigurationState>>
    {
    }
}
