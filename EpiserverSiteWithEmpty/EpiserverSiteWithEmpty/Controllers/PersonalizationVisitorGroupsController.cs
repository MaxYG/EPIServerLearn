using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.Personalization;
using EpiserverSiteWithEmpty.Models.ViewModels;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class PersonalizationVisitorGroupsController : PageControllerBase<PersonalizationVisitorGroups>
    {
        public ActionResult Index(PersonalizationVisitorGroups currentPage)
        {
            var model=new DefaultPageViewModel<PersonalizationVisitorGroups>(currentPage);
            return View("/Views/Learning/PersonalizationVisitorGroups/Index.cshtml", model);
        }
    }
}