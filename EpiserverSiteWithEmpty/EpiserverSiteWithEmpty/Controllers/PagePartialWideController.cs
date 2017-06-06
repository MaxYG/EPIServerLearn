using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    [TemplateDescriptor(Inherited = true, Tags = new string[] {"span8"}, AvailableWithoutTag = false)]
    public class PagePartialWideController : PartialContentController<SitePageData>
    {
        // GET: PagePartialWide
        public override ActionResult Index(SitePageData currentContent)
        {
            return PartialView("/Views/Shared/PagePartials/PagePartialWide.cshtml", currentContent);
        }
    }
}