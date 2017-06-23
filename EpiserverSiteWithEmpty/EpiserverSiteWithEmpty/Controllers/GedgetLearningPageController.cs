using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.GadgetLearning;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Shell.Gadgets;
using EPiServer.Shell.ViewComposition;

namespace EpiserverSiteWithEmpty.Controllers
{
    [Component]
//    [Gadget]
    [EPiServer.Shell.Web.CssResource("Content/QuickChat.css")]
    public class GedgetLearningPageController : PageControllerBase<GedgetLearningPage>
    {
        public ActionResult Index(GedgetLearningPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var model=new DefaultPageViewModel<GedgetLearningPage>(currentPage);
            return View(model);
        }
    }
}