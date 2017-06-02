using System.Web.Mvc;
using System.Web.Security;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Core;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public abstract class PageControllerBase <T>  : PageController<PageData> where T : SitePageData
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}