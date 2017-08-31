using System;
using EPiServer.Events;
using EPiServer.Events.Providers;

namespace EpiserverSiteWithEmpty.Commons
{
    public class EventHelperProvider:EventProvider
    {
        public override void SendMessage(EventMessage message)
        {
            message.Sent = DateTime.Now;
        }
    }
}