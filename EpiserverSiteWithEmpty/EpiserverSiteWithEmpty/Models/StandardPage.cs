using System.ComponentModel.DataAnnotations;
using EpiserverSiteWithEmpty.Models.Blocks;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models
{
    [ContentType(DisplayName = "StandardPage", 
        GUID = "fd197865-7d91-4a6e-9bd7-565eb6249c3b", 
        Description = "Alloy Standard page")]
   
    public class StandardPage : SitePageData
    {
        [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 310)]
                public virtual XhtmlString MainBody { get; set; }

   
        [Display(
                    Name = "Teaser block",
                    Description = "block as property",
                    GroupName = SystemTabNames.Content,
                    Order = 320)]
        public virtual TeaserBlock Teaser { get; set; }

        [Display(
                    GroupName = SystemTabNames.Content,
                    Order = 321)]
        public virtual string Xxx { get; set; }

        
        public virtual string Name { get; set; }

        public void CreateNewPage(PageReference parent)
        {
            var factory = DataFactory.Instance;
            var newPage = factory.GetDefault<StandardPage>(parent);
            newPage.Xxx = "hello world";
            factory.Save(newPage, SaveAction.Publish);
        }
        
    }
    
}