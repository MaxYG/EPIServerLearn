using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpiserverSiteWithEmpty.Models.Learning.Configurations;

namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public class ConfigurationSitePageDataViewModel : IPageViewModel<ConfigurationSitePageData>
    {
        public ConfigurationSitePageDataViewModel(ConfigurationSitePageData configurationSitePageData)
        {
            this.CurrentPage = configurationSitePageData;
        }

        public ConfigurationSitePageData CurrentPage { get; }
        public string ElementName { get; set; }
        public int RemoteWebServiceCulture { get; set; }
       
    }
}