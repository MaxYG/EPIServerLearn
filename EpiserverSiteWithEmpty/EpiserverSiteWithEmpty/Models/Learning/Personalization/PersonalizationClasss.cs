using System.ComponentModel.DataAnnotations;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.DataAnnotations;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;
using EPiServer.Web.WebControls;

namespace EpiserverSiteWithEmpty.Models.Learning.Personalization
{
//    [ContentType]
    public class PersonalizationClasss: CriterionModelBase,IValidateCriterionModel
    {
        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }

        [Required]
        [StringLength(10)]
        [DojoWidget(WidgetType = "dijit.form.FilteringSelect")]
        public string MyString { get; set; }
        public int MyInt { get; set; }

//        [DojoWidget(
//            WidgetType = "dijit.form.FilteringSelect",
//            SelectionFactoryType = typeof(EnumSelectionFactory))]
//        public SomeEnum MyEnumSelector { get; set; }
        public CriterionValidationResult Validate(VisitorGroup currentGroup)
        {
            if (MyString.Length>5)
            {
                return new CriterionValidationResult(false,"MyString is too long!","MyString");
            }
            return new CriterionValidationResult(true);
        }
    }
}