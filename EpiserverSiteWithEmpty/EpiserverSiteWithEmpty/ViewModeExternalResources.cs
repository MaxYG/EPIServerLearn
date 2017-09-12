using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Forms.Helpers.Internal;
using EPiServer.Forms.Implementation;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty
{
    /// <summary>
    /// </summary>
    [ServiceConfiguration(ServiceType = typeof(IViewModeExternalResources))]
    public class ViewModeExternalResources : IViewModeExternalResources
    {
        public virtual IEnumerable<Tuple<string, string>> Resources
        {
            get
            {
                var publicVirtualPath = ModuleHelper.GetPublicVirtualPath("EpiserverSiteWithEmpty");
                var currentPageLanguage = FormsExtensions.GetCurrentPageLanguage();

                var arrRes = new List<Tuple<string, string>>();

                arrRes.Add(new Tuple<string, string>("script", publicVirtualPath+ "/ClientResources/ViewMode/aaaaaaaaaaaaaaaaaaa.js"));

                return arrRes;
            }
        }

    }
}