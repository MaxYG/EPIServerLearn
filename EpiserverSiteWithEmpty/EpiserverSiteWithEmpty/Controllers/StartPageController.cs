using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var defaultPageViewModel = new DefaultPageViewModel<StartPage>(currentPage);
            return View(defaultPageViewModel);
        }
    }
}