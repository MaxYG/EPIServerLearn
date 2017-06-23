using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        public ActionResult Index(SearchPage currentPage,string q)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
             var model=new SearchPageViewModel(currentPage);
            if (!string.IsNullOrEmpty(q))
            {
                model.SearchText = q;
                model.Search(q);
            }
            return View(model);
        }

        
    }
}