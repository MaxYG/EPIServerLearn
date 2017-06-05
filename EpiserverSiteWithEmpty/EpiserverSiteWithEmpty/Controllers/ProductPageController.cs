using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.viewModels;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class ProductPageController : PageControllerBase<ProductPage>
    {
        public ActionResult Index(ProductPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
             var model=new DefaultPageViewModel<ProductPage>(currentPage);
            return View(model);
        }
    }
}