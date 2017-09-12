using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using EpiserverSiteWithEmpty.Learning.logging;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Forms.Core.Events;
using EPiServer.Forms.Core.Models;
using EPiServer.Forms.Helpers.Internal;
using EPiServer.Forms.Implementation;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Framework;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;

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
            var formsEvents = ServiceLocator.Current.GetInstance<FormsEvents>();
            formsEvents.FormsStructureChange += OnStructureChange;
            formsEvents.FormsSubmitting += OnSubmitting1;
            formsEvents.FormsSubmitting += OnSubmitting2;
            formsEvents.FormsStepSubmitted += OnStepSubmit;
            formsEvents.FormsSubmissionFinalized += OnFormFinalized;

            var model = new DefaultPageViewModel<FormsPage>(currentPage);
            return View(model);
        }

        private void OnFormFinalized(object sender, FormsEventArgs e)
        {
            EpiLogging.LoggingMessage(string.Format("Form:{0}[{1}] is finalized",e.FormsContent.Name, e.FormsContent.ContentGuid));
        }

        private void OnStepSubmit(object sender, FormsEventArgs e)
        {
            EpiLogging.LoggingMessage(string.Format("Form:{0}[{1}] has a step submitted",e.FormsContent.Name, e.FormsContent.ContentGuid));
        }

        private void OnSubmitting1(object sender, FormsEventArgs e)
        {
            EpiLogging.LoggingMessage(string.Format("You are submitting Form:{0}[{1}]", e.FormsContent.Name, e.FormsContent.ContentGuid));
        }
        private void OnSubmitting2(object sender, FormsEventArgs args)
        {
            var valueOfFieldToCancel = "xxx";

            var e = args as FormsSubmittingEventArgs;
            var firstField = e.SubmissionData.Data.First();
            if (firstField.Value as string == valueOfFieldToCancel.ToString())
            {
                e.CancelAction = true;
                e.CancelReason = string.Format("AlloyMVC: firstElementValue={0} is too rude. Cancelled.", firstField.Value);
            }
            else
            {
                e.CancelReason = string.Format("AlloyMVC: firstElementValue={0} is OK", firstField.Value);
            }
        }

        private void OnStructureChange(object sender, FormsEventArgs e)
        {
            
            EpiLogging.LoggingMessage(string.Format("Form:{0}[{1}] has changed its structure", e.FormsContent.Name, e.FormsContent.ContentGuid));

            if (e.Data is FormStructure)
            {
                EpiLogging.LoggingMessage(string.Format("New Form structure: {0}", string.Join(",", (e.Data as FormStructure).AllFields)));
            }
        }
    }



   

//    //https://blog.tech-fellow.net/2016/12/26/customize-css-styles-loaded-from-episerver-forms-samples/
//    [InitializableModule]
//    [ModuleDependency(typeof(InitializationModule))]
//    public class InitializationModule1 : IConfigurableModule
//    {
//        public void Initialize(InitializationEngine context) { }
//
//        public void Uninitialize(InitializationEngine context) { }
//
//        public void ConfigureContainer(ServiceConfigurationContext context)
//        {
//            context.Container.Configure(
//                cfg =>
//                        cfg.For<IViewModeExternalResources>()
//                           .DecorateAllWith<CustomResources>());
//        }
//    }
//
//    public class CustomResources : IViewModeExternalResources
//    {
//        private readonly IViewModeExternalResources _inner;
//        private readonly bool _replace;
//
//        public CustomResources(IViewModeExternalResources inner)
//        {
//            _inner = inner;
//            if (inner is ViewModeExternalResources)
//                _replace = true;
//        }
//
//        public IEnumerable<Tuple<string, string>> Resources
//        {
//            get
//            {
//                if (!_replace)
//                    return _inner.Resources;
//
//                return new[]
//                {
//                     new Tuple<string, string>("script", "/ClientResources/ViewMode/loadClientResources.js")
//                };
//            }
//        }
//    }

//    public class CustomResources : IViewModeExternalResources
//    {
//        public IEnumerable<Tuple<string, string>> Resources
//        {
//            get
//            {
//                yield return new Tuple<string, string>("script", "/ClientResources/ViewMode/loadClientResources.js");
////                yield return new Tuple<string, string>("css","/ClientResources/custom.css");
//            }
//        }
//    }
}