using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Forms.Core.Internal;
using EPiServer.Forms.Core.Models;
using EPiServer.Framework;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Commons
{
    //https://www.dcaric.com/blog/creating-placeholders-for-episerver-forms
    public class PlaceholderDemoProvider: IPlaceHolderProvider
    {
        private readonly IContentLoader _contentLoader;
        public const string PageName = "page_name";
        public const string PageId = "page_id";
        public const string PageUrl = "page_url";
        public const string LanguageBranch = "language_branch";
        public const string User = "user";
        public const string BrowserUserAgent = "browser_user_agent";

        public PlaceholderDemoProvider()
        {
            _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
        }

        public IEnumerable<PlaceHolder> ProcessPlaceHolders(IEnumerable<PlaceHolder> availablePlaceHolders, FormIdentity formIden,
            HttpRequestBase requestBase = null, Submission submissionData = null, bool performHtmlEncode = true)
        {
            Validator.ThrowIfNull("formIden", formIden);
            Validator.ThrowIfNull("submissionData", submissionData);
            Validator.ThrowIfNull("availablePlaceHolders", availablePlaceHolders);


            string languageBranch = submissionData.Data[EPiServer.Forms.Constants.SYSTEMCOLUMN_Language].ToString();

            string user = submissionData.Data[EPiServer.Forms.Constants.SYSTEMCOLUMN_SubmitUser].ToString();

            int pageId = int.Parse(submissionData.Data[EPiServer.Forms.Constants.SYSTEMCOLUMN_HostedPage].ToString());


            var placeHolders = availablePlaceHolders as PlaceHolder[] ?? availablePlaceHolders.ToArray();

            foreach (var placeholder in placeHolders)
            {
                if (placeholder.Key == PageName)
                {
                    IContent hostedPage;
                    if (_contentLoader.TryGet(new ContentReference(pageId),new CultureInfo(languageBranch),out hostedPage))
                    {
                        placeholder.Value = hostedPage.Name;
                    }
                }
                if (placeholder.Key == PageId)
                {
                    placeholder.Value = pageId.ToString();
                }
                if (placeholder.Key == LanguageBranch)
                {
                    placeholder.Value = languageBranch;
                }
                if (placeholder.Key == User)
                {
                    placeholder.Value = user;
                }
                if (placeholder.Key == PageUrl && requestBase?.UrlReferrer != null)
                {
                    placeholder.Value = requestBase.UrlReferrer.AbsoluteUri;
                }
                if (placeholder.Key == BrowserUserAgent && requestBase?.UserAgent != null)
                {
                    placeholder.Value = requestBase.UserAgent;
                }
            }

            return placeHolders;
        }

        public int Order {
            get { return 1000; }
            set { }
        }
        public IEnumerable<PlaceHolder> ExtraPlaceHolders {
            get
            {
                return new[]
                {
                    new PlaceHolder(PageName, string.Empty),
                    new PlaceHolder(PageId, string.Empty),
                    new PlaceHolder(LanguageBranch, string.Empty),
                    new PlaceHolder(User, string.Empty),
                    new PlaceHolder(PageUrl, string.Empty),
                    new PlaceHolder(BrowserUserAgent, string.Empty)
                };
            }
        }
    }

    public class PlaceholderDemo2Provider : IPlaceHolderProvider
    {

        public IEnumerable<PlaceHolder> ProcessPlaceHolders(IEnumerable<PlaceHolder> availablePlaceHolders, FormIdentity formIden,
            HttpRequestBase requestBase = null, Submission submissionData = null, bool performHtmlEncode = true)
        {
            return availablePlaceHolders;
        }

        public int Order {
            get { return 1001; }
            set {} }
        public IEnumerable<PlaceHolder> ExtraPlaceHolders {
            get
            {
                return new []
                {
                    new PlaceHolder(CustomePlaceHolderKey,"CustomePlaceHolderValue"), 
                    new PlaceHolder(CustomePlaceHolderKey1,"CustomePlaceHolderValue1"), 
                };
            }
        }

        public string CustomePlaceHolderKey = "CustomePlaceHolderKey";
        public string CustomePlaceHolderKey1 = "CustomePlaceHolderKey1";
    }
}