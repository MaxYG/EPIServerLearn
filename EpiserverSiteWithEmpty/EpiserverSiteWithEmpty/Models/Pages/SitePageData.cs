using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    public abstract class SitePageData:PageData
    {
        [Display(GroupName = "SEO",Order = 100)]
        public virtual string MetaTitle { get; set; }

        [Display(GroupName = "SEO", Order = 200)]
        public virtual string MetaKeywords { get; set; }
        
        [Display(GroupName = "SEO", Order = 300)]
        [UIHint(UIHint.Textarea)]
        public virtual string MetaDescription { get; set; }



        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual EPiServer.Core.ContentReference PageImage { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual string TeaserText { get; set; }
    }
}