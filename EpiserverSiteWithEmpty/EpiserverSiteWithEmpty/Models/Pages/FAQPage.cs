using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "FAQPage", GUID = "4f2c9b6b-f934-4c88-9338-4c98e72c114d", Description = "")]
    public class FAQPage : SitePageData
    {
        [Ignore]
        public IList<FAQItem> FAQItems { get; set; }
    }
}