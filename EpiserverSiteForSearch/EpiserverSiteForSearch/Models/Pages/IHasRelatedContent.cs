using EPiServer.Core;

namespace EpiserverSiteForSearch.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
