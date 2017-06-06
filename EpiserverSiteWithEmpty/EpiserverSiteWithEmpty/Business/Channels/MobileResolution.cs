using EPiServer.Web;

namespace EpiserverSiteWithEmpty.Business.Channels
{
    public class MobileResolution:IDisplayResolution
    {
        public MobileResolution()
        {
            Id = this.GetType().FullName;
            Name = "Mobile(320X480)";
            Width = 320;
            Height = 480;
        }

        public string Id { get; }
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
    }
}