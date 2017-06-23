using EpiserverSiteWithEmpty.Models.Learning.EditHint;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Core;

namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public class EditSamplePageViewModel : IPageViewModel<EditSamplePage>
    {
       
        public EditSamplePageViewModel(EditSamplePage currentPage)
        {
            CurrentPage = currentPage;
        }

        public string Heading { get; set; }
        public string BannerUrl { get; set; }
        public XhtmlString Body { get; set; }
        public XhtmlString SecondaryBody { get; set; }
        public virtual bool ShowBanner { get; set; }
        public EditSamplePage CurrentPage { get; }
    }
}