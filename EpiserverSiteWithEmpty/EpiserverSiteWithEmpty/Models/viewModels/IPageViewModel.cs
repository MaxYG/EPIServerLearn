using EpiserverSiteWithEmpty.Models.Pages;

namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public interface IPageViewModel<out T> where T:SitePageData
    {
        T CurrentPage { get; }
    }
}
