using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.GlobalizationScenario;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Localization;
using EPiServer.Framework.Localization.XmlResources;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class GlobalizationScenarioController : PageControllerBase<GlobalizationScenario>
    {
        public ActionResult Index(GlobalizationScenario currentPage)
        {
            //CreateCulture();
            var localizedString = LocalizationService.Current.AvailableLocalizations;
            //ServiceLocator.Current.GetInstance()


            var model = new DefaultPageViewModel<GlobalizationScenario>(currentPage);
            return View("/Views/Learning/GlobalizationScenario/Index.cshtml", model);
        }

        public static void CreateCulture()
        {
            //* Get the base culture and region information
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            RegionInfo regionInfo = new RegionInfo(cultureInfo.Name);

            //* Create the a locale for en-HK
            CultureAndRegionInfoBuilder cultureAndRegionInfoBuilder = new CultureAndRegionInfoBuilder("en-HK", CultureAndRegionModifiers.Replacement);

            //* Load the base culture and region information
            cultureAndRegionInfoBuilder.LoadDataFromCultureInfo(cultureInfo);
            cultureAndRegionInfoBuilder.LoadDataFromRegionInfo(regionInfo);

            //* Set the culture name
            cultureAndRegionInfoBuilder.CultureEnglishName = "English (Hong Kong)";
            cultureAndRegionInfoBuilder.CultureNativeName = "English (Hong Kong)";
            

            //* Register with your operating system

            cultureAndRegionInfoBuilder.Register();
            
        }
    }


    [InitializableModule]
    [ModuleDependency(typeof(FrameworkInitialization))]
    public class CustomLanguageProviderInitializationWithPhysicalPath : IInitializableModule
    {
        private const string ProviderName = "customResources";
        public void Initialize(InitializationEngine context)
        {
            //Casts the current LocalizationService to a ProviderBasedLocalizationService to get access to the current list of providers
            ProviderBasedLocalizationService localizationService = context.Locate.Advanced.GetInstance<LocalizationService>() as ProviderBasedLocalizationService;
            if (localizationService != null)
            {
                string langFolder = @"c:\temp\resourceFolder";
                if (Directory.Exists(langFolder))
                {
                    NameValueCollection configValues = new NameValueCollection();
                    //This config value tells the provider where to find XML language documents.
                    configValues.Add(FileXmlLocalizationProvider.PhysicalPathKey, langFolder);
                    FileXmlLocalizationProvider localizationProvider = new FileXmlLocalizationProvider();
                    //Instanciates the provider
                    localizationProvider.Initialize(ProviderName, configValues);
                    //Adds it at the end of the list of providers.
                    localizationService.Providers.Add(localizationProvider);
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Casts the current LocalizationService to a ProviderBasedLocalizationService to get access to the current list of providers
            ProviderBasedLocalizationService localizationService = context.Locate.Advanced.GetInstance(typeof(string)) as ProviderBasedLocalizationService;
            if (localizationService != null)
            {
                //Gets any provider that has the same name as the one initialized.
                LocalizationProvider localizationProvider = localizationService.Providers.FirstOrDefault(p => p.Name.Equals(ProviderName, StringComparison.Ordinal));
                if (localizationProvider != null)
                {
                    //If found, remove it.
                    localizationService.Providers.Remove(localizationProvider);
                }
            }
        }

        public void Preload(string[] parameters) { }
    }
}