using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.AdminInterface;
using EpiserverSiteWithEmpty.Models.Learning.PingPang;
using EpiserverSiteWithEmpty.Models.ViewModels;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class SchedulePingPangController : PageControllerBase<SchedulePingPang>
    {
        public ActionResult Index(AdminInterface currentPage)
        {

            var model = new DefaultPageViewModel<AdminInterface>(currentPage);
            return View("/Views/Learning/AdminInterface/Index.cshtml", model);
        }
    }
}