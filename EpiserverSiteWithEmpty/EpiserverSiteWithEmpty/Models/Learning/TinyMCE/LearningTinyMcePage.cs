using System;
using System.Web.Configuration;
using EpiserverSiteWithEmpty.Learning.CustomProperty;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Learning.TinyMCE
{
    [ContentType]
    public class LearningTinyMcePage: SitePageData
    {
        //添加xmhtml属性

        public virtual XhtmlString TinyMcexxx { get; set; }

        [PropertySettings(typeof(SimpleTinyMCESettings))]
        public virtual XhtmlString CustomPropertySidebar { get; set; }
    }
}