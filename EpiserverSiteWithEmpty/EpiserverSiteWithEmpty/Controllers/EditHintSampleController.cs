using System.Web;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.EditHint;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class EditHintSampleController : PageControllerBase<EditSamplePage>
    {
        public ActionResult Index(EditSamplePage currentPage)
        {
            var model = new EditSamplePageViewModel(currentPage)
            {
                Heading = currentPage.MyText,
                Body = currentPage.MainBody,
                SecondaryBody = currentPage.SecondaryBody,
                BannerUrl = currentPage.BannerUrl.ToString(),
                ShowBanner = currentPage.ShowBanner,
            };
            
            var editingHints = ViewData.GetEditHints<EditSamplePageViewModel, EditSamplePage>();
            editingHints.AddConnection(m => m.Heading, p => p.MyText);

            editingHints.AddFullRefreshFor(x=>x.ShowBanner);

            return View(model);
        }
    }
}