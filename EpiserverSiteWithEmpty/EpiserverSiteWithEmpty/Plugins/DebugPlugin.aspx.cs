using System;
using System.Text;
using EPiServer.Cms.Shell.ViewComposition;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace EpiserverSiteWithEmpty.Plugins
{
    [IFrameComponent(
        Url = "~/Plugins/DebugPlugin.aspx",
        ReloadOnContextChange = true,
        PlugInAreas = EPiServer.Shell.PlugInArea.Assets,
        Title = "Property Debugger",
        Categories = "cms",
        MinHeight = 200,
        MaxHeight = 700)]
    public partial class DebugPlugin : EPiServer.Shell.WebForms.ContentWebFormsBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GetTableHeader("Properties"));
            sb.Append(GetTableRowWithColspan1("<b>Name</b>", "<b>Value</b>"));
            string EmptyValuePlaceholder = "(Empty)";

            foreach (PropertyData pd in CurrentContent.Property)
            {
                // If the Property is a PropertyContentArea, get each content item contained in the Content Area and output its properties.
                if (pd.GetType() == typeof(PropertyContentArea))
                {
                    PropertyContentArea pca = pd as PropertyContentArea;
                    sb.Append(GetTableRowWithColspan2(string.Format("Content Area: '{0}'", pca.Name)));

                    //Do not try to list items in the content area if it is empty
                    if (pca.IsNull)
                    {
                        sb.Append(GetTableRowWithColspan1(EmptyValuePlaceholder, string.Empty));
                    }
                    else
                    {
                        ContentArea ca = pca.Value as ContentArea;
                        foreach (ContentAreaItem cai in ca.Items)
                        {
                            IContent c = cai.GetContent();

                            //Write out the name of the IContent
                            sb.Append(GetTableRowWithColspan2(string.Format("Content item name: '{0}'", c.Name)));
                            sb.Append(GetTableRowWithColspan2(string.Format("Properties:")));
                            sb.Append(GetTableRowWithColspan1("<b>Name</b>", "<b>Value</b>"));

                            //Loop through the IContent and write out property names and values
                            foreach (PropertyData p in c.Property)
                            {
                                sb.Append(GetTableRowWithColspan1(p.Name, p.Value != null ? p.Value.ToString() : EmptyValuePlaceholder));
                            }
                        }
                    }
                }
                // If it's not a PropertyContentArea, just output the Name/Value pair.
                else
                {
                    sb.Append(GetTableRowWithColspan1(pd.Name, pd.Value != null ? pd.Value.ToString() : EmptyValuePlaceholder));
                }
            }

            sb.Append(GetTableFooter());

            LitCtrl.Text = sb.ToString();
        }

        private string GetTableHeader(string headerText)
        {
            return "<table border='1' width='500'><tr><th colspan='2'>" + headerText + "</th></tr>";
        }

        private string GetTableRowWithColspan1(string firstCellText, string secondCellText)
        {
            return "<tr><td>" + firstCellText + "</td><td>" + secondCellText + "</td></tr>";
        }

        private string GetTableRowWithColspan2(string cellText)
        {
            return "<tr><td colspan='2'><B>" + cellText + "</B></td>" + "</tr>";
        }

        private string GetTableFooter()
        {
            return "</table><br/>";
        }
    }
}