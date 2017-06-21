using System.Web.Mvc;
using System.Web.Security;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public abstract class PageControllerBase <T>  : PageController<T> where T : SitePageData
    {
        public ActionResult Logout()
        {
//            DataFactory.Instance.GetPage(new PageReference(123));
//            DataFactory.Instance.Delete(new PageReference(123),true);
           

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}