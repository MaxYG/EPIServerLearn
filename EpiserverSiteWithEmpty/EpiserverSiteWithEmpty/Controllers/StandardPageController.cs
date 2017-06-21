using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class StandardPageController : PageControllerBase<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
//            var factory = DataFactory.Instance;
//            factory.FindPagesWithCriteria()
            var model = new DefaultPageViewModel<StandardPage>(currentPage);
            return View(model);
        }
    }
}