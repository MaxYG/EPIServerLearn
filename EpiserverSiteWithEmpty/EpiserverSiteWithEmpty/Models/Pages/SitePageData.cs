using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
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

        [Display(GroupName = "Selection", Order = 100)]
        [SelectOne(SelectionFactoryType = typeof(LanguageSelectionFactoryType))]
        public virtual string SingleLanguage { get; set; }

        [Display(GroupName = "Selection", Order = 101)]
        [SelectMany(SelectionFactoryType = typeof(LanguageSelectionFactoryType))]
        public virtual string MultipleLanguage { get; set; }

        [Display(GroupName = "Selection", Order = 101)]
        [LanguageSelectionOne]
        public virtual string SingleLanguageAttr { get; set; }

        [Display(GroupName = "Selection", Order = 101)]
        [LanguageSelectionMultiple]
        public virtual string MultipleLanguageAttr { get; set; }

        [Display(GroupName = "Selection", Order = 101)]
        [UIHint("Banana", PresentationLayer.Website)]
        public virtual string UIHintXXX { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            MetaTitle = "Set value not work";
            
        }
    }

    //Setting up single or multiple list options
    public class LanguageSelectionFactoryType : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() {Text = "English", Value = "EN"},
                new SelectItem() {Text = "Swahili", Value = "SW"},
                new SelectItem() {Text = "French Polonesia", Value = "PF"}
            };
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LanguageSelectionOneAttribute : SelectOneAttribute
    {
        public override Type SelectionFactoryType
        {
            get
            {
                return typeof(LanguageSelectionFactory);
            }
            set
            {
                base.SelectionFactoryType = value;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class LanguageSelectionMultipleAttribute : SelectManyAttribute
    {
        public override Type SelectionFactoryType
        {
            get
            {
                return typeof(LanguageSelectionFactory);
            }
            set
            {
                base.SelectionFactoryType = value;
            }
        }
    }
}