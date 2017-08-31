using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.Configurations;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Cms.Shell.UI.Models.ExternalLinks;
using EPiServer.Core;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class ConfigurationDemoController :  PageControllerBase<ConfigurationSitePageData>
    {
        // GET: ConfigurationDemo
        public ActionResult Index(ConfigurationSitePageData currentPage)
        {
            

            var model = new ConfigurationSitePageDataViewModel(currentPage)
            {
                ElementName = EPiServer.Configuration.Settings.Instance.ElementName,
                RemoteWebServiceCulture = EPiServer.Configuration.Settings.Instance.RemoteWebServiceCulture
            //ElementName = EPiServer.Configuration.Settings.Instance.MapHostToSettings()
        };
            //            var model = new DefaultPageViewModel<ConfigurationSitePageData>(currentPage);
            //model.CurrentPage.ElementName = EPiServer.Configuration.Settings.Instance.UIMaxVersions.ToString();
            //            var xxx=EPiServer.Configuration.Settings.Instance.UIMaxVersions;
            //model.ElementName= EPiServer.Configuration.Settings.Instance.ElementName;
            var remoteWebServiceCulture=EPiServer.Configuration.Settings.Instance.RemoteWebServiceCulture;
            return View("/Views/Learning/Configurations/Index.cshtml", model);
        }
    }
}