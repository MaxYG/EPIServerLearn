using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using EPiServer.Personalization.VisitorGroups;

namespace EpiserverSiteWithEmpty.Views.Shared.EditorTemplates
{
    public class Criterion1Model : CriterionModelBase, IValidateCriterionModel
    {
        #region Editable Properties

        // TODO:
        // Add your model's editable properties here.
        // Decorate them with the DojoWidget attribute to
        // steer the control used to present the property
        // in the Visitor Group Admin UI

        #endregion

        public override ICriterionModel Copy()
        {
            // TODO:
            // If your model uses only built-in CLR types
            // then you can safely return base.ShallowCopy()
            // otherwise you need to add logic to do a deep copy
            return base.ShallowCopy();
        }

        [Required]
        [StringLength(10)]
        [DojoWidget(WidgetType = "dijit.form.FilteringSelect")]
        public string MyString { get; set; }
        public int MyInt { get; set; }

        public CriterionValidationResult Validate(VisitorGroup currentGroup)
        {
            if (MyString.Length > 5)
            {
                return new CriterionValidationResult(false, "MyString is too long!", "MyString");
            }
            return new CriterionValidationResult(true);
        }
    }
}
