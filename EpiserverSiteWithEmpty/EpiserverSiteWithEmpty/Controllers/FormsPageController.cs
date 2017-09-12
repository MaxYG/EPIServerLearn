using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Forms.Core.Events;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Controllers
{
    //Forms Demo
    public class FormsPageController : PageControllerBase<FormsPage>
    {
        public ActionResult Index(FormsPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            // get the Forms Event Manager to listen to its events
//            var formsEvents = ServiceLocator.Current.GetInstance<FormsEvents>();
//            formsEvents.FormsStructureChange += OnStructureChange;
//            formsEvents.FormsSubmitting += OnSubmitting1;
//            formsEvents.FormsSubmitting += OnSubmitting2;
//            formsEvents.FormsStepSubmitted += OnStepSubmit;
//            formsEvents.FormsSubmissionFinalized += OnFormFinalized;

            var model = new DefaultPageViewModel<FormsPage>(currentPage);
            return View(model);
        }
    }
}