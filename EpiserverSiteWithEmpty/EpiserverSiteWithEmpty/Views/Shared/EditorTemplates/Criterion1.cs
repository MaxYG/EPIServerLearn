using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EPiServer.Personalization.VisitorGroups;

namespace EpiserverSiteWithEmpty.Views.Shared.EditorTemplates
{
    [VisitorGroupCriterion(DisplayName = "Criterion1",
        ScriptUrl = "Views/Shared/EditorTemplates/Criterion1.js")]
    public class Criterion1 : CriterionBase<Criterion1Model>
    {
        public override bool IsMatch(System.Security.Principal.IPrincipal principal, HttpContextBase httpContext)
        {
            // TODO:
            // Satisfy if the current request is a match using the
            // criterion's logic amd model.
            // The model instance can be accessed via the Model property
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
        void criterionEvents_StartRequest(object sender, CriterionEventArgs e)
        {
            // Handle the event
            
        }
    }
}
