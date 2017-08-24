using System.Web.Mvc;
using EpiserverSiteWithEmpty.Learning.logging;
using EpiserverSiteWithEmpty.Models.Learning.AdminInterface;
using EpiserverSiteWithEmpty.Models.Learning.GlobalizationScenario;
using EpiserverSiteWithEmpty.Models.Learning.Logging;
using EpiserverSiteWithEmpty.Models.ViewModels;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class AdminInterfaceController : PageControllerBase<AdminInterface>
    {
        public ActionResult Index(AdminInterface currentPage)
        {
            
            var model = new DefaultPageViewModel<AdminInterface>(currentPage);
            return View("/Views/Learning/AdminInterface/Index.cshtml", model);
        }
    }

    
}