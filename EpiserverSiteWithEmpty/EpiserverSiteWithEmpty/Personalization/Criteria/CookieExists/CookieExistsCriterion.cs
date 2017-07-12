using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using EPiServer.Personalization.VisitorGroups;

namespace EpiserverSiteWithEmpty.Personalization.Criteria.CookieExists
{
    [VisitorGroupCriterion(Category = "Technical",
        DisplayName = "Cookie exists",
        Description = "checks if a specific cookie exists")]
    public class CookieExistsCriterion:CriterionBase<CookieExistsCriterionSettings>
    {
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            return httpContext.Request.Cookies[Model.CookieName] != null;
        }
    }
}