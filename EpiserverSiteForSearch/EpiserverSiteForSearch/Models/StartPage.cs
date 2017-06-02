using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverSiteForSearch.Models
{
    [ContentType(DisplayName = "StartPage", GUID = "b860ebc9-3949-45f7-8853-5e05009828b7", Description = "")]
   
    public class StartPage : PageData
    {
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }

                [Display(
                    GroupName = SystemTabNames.Content,
                    Order = 0
                    )]
                public virtual string Heading {get;set;}
    }
}