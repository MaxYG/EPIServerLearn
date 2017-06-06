


using System.Web;
using EPiServer.Web;

namespace EpiserverSiteWithEmpty.Business.Channels
{
    public class MobileChannel : DisplayChannel
    {
        public MobileChannel()
        {
            ResolutionId = typeof(MobileResolution).FullName;
            ChannelName = "Mobile";
        }

        public override bool IsActive(HttpContextBase context)
        {
            return true;
        }

        public override string ChannelName { get; }

        public override string ResolutionId { get; }
    }
}