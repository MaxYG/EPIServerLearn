using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    [TemplateDescriptor(Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController,
        Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
        AvailableWithoutTag = false)]
    public class PreviewController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        public ActionResult Index(IContent currentContent)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.Get<PageData>(ContentReference.StartPage);
            var model = new BlockEditPageViewModel(startPage, currentContent);

            return View(model);
        }
    }
}
