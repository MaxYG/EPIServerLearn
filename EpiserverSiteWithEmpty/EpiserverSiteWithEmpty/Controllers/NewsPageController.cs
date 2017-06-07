using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class NewsPageController : PageControllerBase<NewsPage>
    {
        [ContentOutputCache]
        public ActionResult Index(NewsPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var model=new DefaultPageViewModel<NewsPage>(currentPage);
            return View(model);
        }
    }
}