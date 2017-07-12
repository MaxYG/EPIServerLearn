using System.Security.Principal;
using System.Web;
using EPiServer.Personalization.VisitorGroups;

namespace EpiserverSiteWithEmpty.Models.Learning.Personalization
{
    [VisitorGroupCriterion(
        Category = "My Criteria Category",
        Description = "How the criterion works",
        DisplayName = "Short Name",
        LanguagePath = "/xml/path/to/translations/",
        ScriptUrl = "javascript-that-should-be-loaded-for-the-UI.js")]
    public class YourCriterionClass : CriterionBase<PersonalizationClasss>
    {
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            return true;
        }

        public override void Subscribe(ICriterionEvents criterionEvents)
        {
            criterionEvents.StartRequest += criterionEvents_StartRequest;
        }

        public override void Unsubscribe(ICriterionEvents criterionEvents)
        {
            criterionEvents.StartRequest -= criterionEvents_StartRequest;
        }

        public void criterionEvents_StartRequest(object sender, CriterionEventArgs e)
        {
        }
    }
}