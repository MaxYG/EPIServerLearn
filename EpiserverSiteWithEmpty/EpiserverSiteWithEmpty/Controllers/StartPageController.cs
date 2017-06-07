using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;


namespace EpiserverSiteWithEmpty.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var defaultPageViewModel = new DefaultPageViewModel<StartPage>(currentPage);
            return View(defaultPageViewModel);
        }
    }
}