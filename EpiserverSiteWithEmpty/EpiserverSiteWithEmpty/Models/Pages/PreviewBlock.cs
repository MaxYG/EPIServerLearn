using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    public class PreviewBlock:PageData
    {
        public IContent PreviewContent { get; set; }
        public ContentArea ContentArea { get; set; }

        public PreviewBlock(PageData currentPage, IContent previewContent)
            : base(currentPage)
        {
            this.PreviewContent = previewContent;
            this.ContentArea = new ContentArea();
            this.ContentArea.Items.Add(new ContentAreaItem
            {
                ContentLink = this.PreviewContent.ContentLink
            });
        }
    }
}