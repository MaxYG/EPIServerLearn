using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.DataAnnotations;
using EPiServer.Core;

namespace EpiserverSiteWithEmpty.Models.Learning.Configurations
{
    [ContentType]
    public class ConfigurationSitePageData:SitePageData
    {
        public virtual XhtmlString PresetImageEditor { get; set; }
    }
}