using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Learning.EditHint
{
    //http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-CMS/9/Content/Edit-hints-in-MVC/
    //    [ContentType(DisplayName = "EditSamplePage", GUID = "8e628093-a005-42b7-aadd-b648121abb1c", Description = "")]
    [ContentType]
    public class EditSamplePage : SitePageData
    {
        public virtual string MyText { get; set; }
        public virtual XhtmlString MainBody { get; set; }
        public virtual XhtmlString SecondaryBody { get; set; }
        public virtual Url BannerUrl { get; set; }
        public virtual bool ShowBanner { get; set; }
        public virtual EditSampleBlock TextBlock { get; set; }
    }
}