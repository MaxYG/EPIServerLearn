using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction.Migration;
using EPiServer.Forms.Core.Data;
using EPiServer.Forms.Core.Models.Internal;
using EPiServer.Forms.Core.PostSubmissionActor;
using EPiServer.Forms.EditView;
using EPiServer.Forms.Implementation.Actors;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace EpiserverSiteWithEmpty.Commons
{
    //https://www.dcaric.com/blog/episerver-forms-3-custom-actors

    
    public class CustomActor:PostSubmissionActorBase,IUIPropertyCustomCollection
    {
       
        private readonly Injected<IFormDataRepository> _formDataRepository;
        public override object Run(object input)
        {
            //skip execution if keyvaluepair is empty
            var model = Model as List<KeyValuePairModel>;
            if (model==null || !model.Any())
            {
                return string.Empty;
            }

            //skip execution if "runcustomeractor" is not set to "true", the "runcustomerector" is come from setting of forms
            var pair = model.FirstOrDefault(x => x.Key == "runCustomActor");
            if (pair==null || pair.Value!="true")
            {
                return string.Empty;
            }


            var submittedData = SubmissionData.Data;
            foreach (var key in submittedData.Keys)
            {
                var xx=submittedData[key].ToString();
            }

            var friendlySubmittedData =
                _formDataRepository.Service.TransformSubmissionDataWithFriendlyName(SubmissionData.Data,SubmissionFriendlyNameInfos, true).ToList();
            var messageDto = friendlySubmittedData.ToObject<MessageDto>();




            return string.Empty;
        }

        public Type PropertyType {
            get { return typeof (KeyValuePairProperty); }
        }
    }

    public class MessageDto
    {
        [FriendlyName("First name")]
        public string FirstName { get; set; }
        [FriendlyName("Last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FriendlyNameAttribute : Attribute
    {
        public string Name { get; set; }
        public FriendlyNameAttribute(string name)
        {
            this.Name = name;
        }
    }

    public static class ObjectMapper
    {
        public static T ToObject<T>(this List<KeyValuePair<string,object>> source) where T:class ,new()
        {
            var newObject=new T();
            var newObjectType = newObject.GetType();
            var properties = newObjectType.GetProperties();
            foreach (var propertie in properties)
            {
                string friendlyName = GetFriendlyName(propertie);
                string key = !string.IsNullOrWhiteSpace(friendlyName) ? friendlyName : propertie.Name;
                SetPropertyValue(newObject,propertie,key,source);
            }

            return newObject; 
        }

        private static void SetPropertyValue<T>(T newObject, PropertyInfo propertie, string key, List<KeyValuePair<string, object>> source)
        {
            if (source.Any(x=>x.Key==key))
            {
                propertie.SetValue(newObject,source.First(x=>x.Key==key).Value);
            }
        }

        private static string GetFriendlyName(PropertyInfo propertie)
        {
            var customAttributes = propertie.GetCustomAttributes(true);
            foreach (var customAttribute in customAttributes)
            {
                var formFieldNameAttribute = customAttribute as FriendlyNameAttribute;
                if (formFieldNameAttribute!=null)
                {
                    return formFieldNameAttribute.Name;
                }
            }
            return string.Empty;
        }
    }

    [Serializable]
    public class KeyValuePairModel : IPostSubmissionActorModel, ICloneable
    {
        [Display(Order = 100)]
        public virtual string Key { get; set; }

        [Display(Order = 200)]
        public virtual string Value { get; set; }

        public object Clone()
        {
            return new KeyValuePairModel
            {
                Key = Key,
                Value = Value
            };
        }
    }
    [EditorHint(nameof(KeyValuePairProperty))]
    [PropertyDefinitionTypePlugIn]
    public class KeyValuePairProperty : PropertyGenericList<KeyValuePairModel>
    {
    }

    [EditorDescriptorRegistration(TargetType = typeof(IEnumerable<KeyValuePairModel>), UIHint = nameof(KeyValuePairProperty))]
    public class KeyValuePairEditorDescriptor : CollectionEditorDescriptor<KeyValuePairModel>
    {
        public KeyValuePairEditorDescriptor()
        {
            ClientEditingClass = "epi-forms/contentediting/editors/CollectionEditor";
        }
    }

    public class MyMigrationStep : MigrationStep
    {
        public override void AddChanges()
        {
            ContentType(nameof(FormContainerBlock)).Property("MyCustomActor").UsedToBeNamed("CustomActor");
        }
    }

}