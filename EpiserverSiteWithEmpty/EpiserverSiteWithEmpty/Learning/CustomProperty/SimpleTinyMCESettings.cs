using System;
using System.Collections.Generic;
using EPiServer.Core.PropertySettings;
using EPiServer.Editor.TinyMCE;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Learning.CustomProperty
{
    [ServiceConfiguration(ServiceType = typeof(PropertySettings))]
    public class SimpleTinyMCESettings:PropertySettings<TinyMCESettings>
    {
        public override Guid ID => new Guid("D1A6D052-CFB4-494C-90E3-A1B402DFDE6A");

        public SimpleTinyMCESettings()
        {
            DisplayName = "Simple editor";
        }

        public override TinyMCESettings GetPropertySettings()
        {
            var settings=new TinyMCESettings();

            var mainToolbar=new ToolbarRow(new List<string>()
            {
                TinyMCEButtons.Bold,
                TinyMCEButtons.Italic,
                TinyMCEButtons.Cut,
                TinyMCEButtons.Copy,
                TinyMCEButtons.Paste,
                TinyMCEButtons.EPiServerLink,
                TinyMCEButtons.Unlink
            });

            settings.ToolbarRows.Add(mainToolbar);
            settings.Height = 30;
            settings.Width = 200;

            return settings;
        }
    }
}