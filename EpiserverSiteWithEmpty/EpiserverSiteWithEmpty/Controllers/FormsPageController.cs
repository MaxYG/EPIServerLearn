using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class FormsPageController : PageControllerBase<FormsPage>
    {
        public ActionResult Index(FormsPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var model = new DefaultPageViewModel<FormsPage>(currentPage);
            return View(model);
        }
    }
}