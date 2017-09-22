using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiBootstrapArea;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;

namespace EpiserverSiteWithEmpty.Commons.RenderMultiColumnFormContainerBlock
{
    //https://blog.tech-fellow.net/2016/09/05/apply-displayoption-for-episerver-forms-elements/
    //https://github.com/valdisiljuconoks/EPiBootstrapArea
    public class RenderMultiColumnForm
    {
    }

    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CustomizedRenderingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ConfigurationContext.Setup(ctx =>
            {
                ctx.RowSupportEnabled = true;
                ctx.AutoAddRow = true;
            });
        }

        public void Uninitialize(InitializationEngine context) { }
    }
    
}