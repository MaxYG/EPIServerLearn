using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class PagePartialController : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentContent)
        {
            return PartialView("/Views/Shared/PagePartials/PagePartial.cshtml", currentContent);
        }
    }
}