using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Personalization.VisitorGroups;

namespace EpiserverSiteWithEmpty.Personalization.Criteria.CookieExists
{
    public class CookieExistsCriterionSettings:CriterionModelBase
    {
        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }

        [Required]
        public string CookieName { get; set; }
    }
}