using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using EPiServer.Forms.Core;
using EPiServer.Forms.Core.Models;
using EPiServer.Forms.Implementation;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Commons
{
    public class RedirectToThankYouPage
    {
    }


    //todo:T how to use it?
    [ServiceConfiguration(typeof(IAppendExtraInfoToRedirection))]
    public class AppendInfoToRedirection : DefaultAppendExtraInfoToRedirection
    {
        public override IDictionary<string, object> GetExtraInfo(FormIdentity formIden, Submission submission)
        {
            // base.GetExtraInfo(formIden, submission);
            var info = base.GetExtraInfo(formIden, submission);
            info.Add("DemoParam","demo value");
            info.Add("FormSubmissionId",submission.Id);
            return info;
        }
    }

    public class DemoInitializationModule : IInitializableModule, IConfigurableModule
    {
        protected ServiceConfigurationContext _ServiceConfigurationContext;

        public void Preload(string[] parameters)
        {
        }

        public void Initialize(InitializationEngine context)
        {
           //_ServiceConfigurationContext.Container.Configure(c=>c.For<IAppendExtraInfoToRedirection>().Use(new AppendInfoToRedirection()));
            _ServiceConfigurationContext.StructureMap().Configure(c => c.For<IAppendExtraInfoToRedirection>().Use(new AppendInfoToRedirection()));

        }

        public void Uninitialize(InitializationEngine context)
        {
           
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            _ServiceConfigurationContext = context;
        }
    }




}