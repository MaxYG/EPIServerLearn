using EpiserverSiteWithEmpty.Models.Pages;

namespace EpiserverSiteWithEmpty.Models.viewModels
{
    public interface IPageViewModel<out T> where T:SitePageData
    {
        T CurrentPage { get; }
    }
}
