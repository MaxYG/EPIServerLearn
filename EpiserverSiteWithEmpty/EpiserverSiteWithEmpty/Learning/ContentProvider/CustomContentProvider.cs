using EPiServer.Core;

namespace EpiserverSiteWithEmpty.Learning.ContentProvider
{
    public class CustomContentProvider:EPiServer.Core.ContentProvider
    {
        protected override IContent LoadContent(ContentReference contentLink, ILanguageSelector languageSelector)
        {
            
            throw new System.NotImplementedException();
        }
    }
}