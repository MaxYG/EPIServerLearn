using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.TinyMCE;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class TinyMceController : PageController<LearningTinyMcePage>
    {
        public ActionResult Index(LearningTinyMcePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
             var model=new DefaultPageViewModel<LearningTinyMcePage>(currentPage);
            return View("/Views/Learning/TinyMce/Index.cshtml", model);
        }
    }
}