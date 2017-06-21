using System.Collections.Generic;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Validation;

namespace EpiserverSiteWithEmpty.Models.Validator
{
    public class SitePageDataValidator : EPiServer.Validation.IValidate<SitePageData> 
    {
        public IEnumerable<ValidationError> Validate(SitePageData instance)
        {
//            if (!instance.MetaTitle.Contains("X"))
//            {
//                return new[]
//                {
//                    new ValidationError
//                    {
//                        ErrorMessage = "Should not start with X",
//                        Severity = ValidationErrorSeverity.Error
//                    }
//                };
//            }
            return new List<ValidationError>();
        }
    }
}