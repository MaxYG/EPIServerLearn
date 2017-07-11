using System.Web.Mvc;
using EpiserverSiteWithEmpty.Learning.logging;
using EpiserverSiteWithEmpty.Models.Learning.DynamicDataStore;
using EpiserverSiteWithEmpty.Models.Learning.Logging;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Packaging.Utility;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class LoggingDemoController : PageControllerBase<LoggingDemo>
    {
        public ActionResult Index(LoggingDemo currentPage)
        {
            EpiLogging.LoggingMessage("test123");
            var model = new DefaultPageViewModel<LoggingDemo>(currentPage);
            return View("/Views/Learning/Logging/Index.cshtml", model);
        }
    }
}