using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Core;
using EPiServer.Forms.Core.Models;
using EPiServer.Forms.Core.Validation;
using EPiServer.Forms.EditView;
using EPiServer.Forms.EditView.DataAnnotations;
using EPiServer.Forms.Implementation.Elements.BaseClasses;
using EPiServer.Forms.Implementation.Validation;
using EPiServer.Framework.Localization;
using EPiServer.Framework.Web.Resources;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Modules;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web.Routing;

namespace EpiserverSiteWithEmpty.Commons.FormElementWithACustomValidator
{
    //https://blog.i4code.nl/episerver-forms-validator-with-settings/
    public class MinimumStringLengthValidationModel : ValidationModelBase
    {
        public int MinimumLength { get; set; }
    }

    public class MinimumStringLengthValidator : ElementValidatorBase, IPreviewableTextBox
    {
        public override bool? Validate(IElementValidatable targetElement)
        {
            int minLength = (this.BuildValidationModel(targetElement)
                as MinimumStringLengthValidationModel).MinimumLength;

            string submittedValue = targetElement.GetSubmittedValue() as string;
            if (!string.IsNullOrWhiteSpace(submittedValue))
                return new bool?(submittedValue.Length >= minLength);

            return new bool?(true);
        }

        public override IValidationModel BuildValidationModel(IElementValidatable targetElement)
        {
            var validationModel =
                base.BuildValidationModel(targetElement) as MinimumStringLengthValidationModel;

            if (validationModel != null)
                validationModel.Message =
                    string.Format(validationModel.Message, validationModel.MinimumLength);

            return validationModel;

        }

        public override void Initialize(string rawStringOfSettings)
        {
            base.Initialize(rawStringOfSettings);
            int minLength = 0;
            this._model = new MinimumStringLengthValidationModel
            {
                MinimumLength = int.TryParse(rawStringOfSettings, out minLength) ? minLength : 0
            };
        }
    }
}