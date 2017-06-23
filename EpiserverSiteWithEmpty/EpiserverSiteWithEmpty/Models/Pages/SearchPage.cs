using System.ComponentModel.DataAnnotations;
using EpiserverSiteWithEmpty.Commons;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "SearchPage", GUID = "92c544b5-f556-4ca6-9e9e-a8b930c3bbe2", Description = "")]
    public class SearchPage : SitePageData
    {
        [UIHint("LineBreaked")]
        [UIHint(UIHint.Textarea, PresentationLayer.Edit)]
        public virtual string Intro { get; set; }
        

        [UIHint("Currency")]
        [UIHint(UIHint.Textarea, PresentationLayer.Edit)]
        public virtual string MoneyDemo { get; set; }


        [UIHint("ChangeColorForMe")]
        [UIHint(UIHint.Textarea, PresentationLayer.Edit)]
        public virtual string Username { get; set; }

        [UIHint("MyRole")]
        public virtual RoleEnum Role { get; set; }
    }
}