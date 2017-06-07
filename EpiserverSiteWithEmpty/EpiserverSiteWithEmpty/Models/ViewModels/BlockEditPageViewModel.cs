using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Core;

namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public class BlockEditPageViewModel:IPageViewModel<SitePageData>
    {
        public BlockEditPageViewModel(PageData page, IContent content)
        {
            previewBlock = new PreviewBlock(page, content);
            CurrentPage = page as SitePageData;
        }
        public PreviewBlock previewBlock { get; set; }
        public SitePageData CurrentPage { get; set; }

    }
}