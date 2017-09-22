using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class Form2PageController : PageControllerBase<Form2Page>
    {
        public ActionResult Index(Form2Page currentPage)
        {
            var defaultPageViewModel = new DefaultPageViewModel<Form2Page>(currentPage);
            return View(defaultPageViewModel);
        }
    }
}