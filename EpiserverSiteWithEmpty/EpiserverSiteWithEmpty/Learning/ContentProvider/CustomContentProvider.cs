/*using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EPiServer;
using EPiServer.Configuration;
using EPiServer.Construction;
using EPiServer.Construction.Internal;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using EPiServer.Shell.ViewComposition;

namespace EpiserverSiteWithEmpty.Learning.ContentProvider
{
    public class AttendeeProvider : EPiServer.Core.ContentProvider
    {
        public const string Key = "attendees";
        private List<Attendee> _attendees = new List<Attendee>();
        protected Injected<IdentityMappingService> IdentityMappingService { get; set; }
        protected override IContent LoadContent(ContentReference contentLink, ILanguageSelector languageSelector)
        {
            MappedIdentity mappedIdentity = IdentityMappingService.Service.Get(contentLink);
            // the email is found in the ExternalIdentifier that was created earlier. Note that Segments[1] is used due to the fact that the ExternalIdentifier is of type Uri.
            // It contains two segments. Segments[0] contains the content provider key, and Segments[1] contains the unique path, which is the e-mail in this case.
            string email = mappedIdentity.ExternalIdentifier.Segments[1];
//            return ConvertToAttendee(PersonService.GetPersonByEmail(email));
            return ConvertToAttendee(new Person());
        }

        protected override IList<GetChildrenReferenceResult> LoadChildrenReferencesAndTypes(
        ContentReference contentLink, string languageID, out bool languageSpecific)
        {
            // the attendees are not language specific, so this is ignored.
            languageSpecific = false;



            // get all Person objects

            var person=new PersonService();
            var people = person.GetAll();

            // create and return GetChildrenReferenceResults. The ContentReference (ContentLink) is fetched using the IdentityMapingService.
            return people.Select(p =>
                new GetChildrenReferenceResult()
                {
                    ContentLink =
                        IdentityMappingService.Service.Get(MappedIdentity.ConstructExternalIdentifier(ProviderKey,
                            p.Email)).ContentLink,
                    ModelType = typeof(Attendee)
                }).ToList();
        }

        public static ContentFolder GetEntryPoint(string name)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var folder = contentRepository.GetBySegment(ContentReference.RootPage, name, LanguageSelector.AutoDetect()) as ContentFolder;
            if (folder == null)
            {
                folder = contentRepository.GetDefault<ContentFolder>(ContentReference.RootPage);
                folder.Name = name;
                contentRepository.Save(folder, SaveAction.Publish, AccessLevel.NoAccess);
            }
            return folder;
        }

        public void Initialize(InitializationEngine context)
        {
            var attendeeProvider = new AttendeeProvider();

            // add configuration settings for entry point and capabilites
            var providerValues = new NameValueCollection();
            providerValues.Add(ContentProviderElement.EntryPointString, AttendeeProvider.GetEntryPoint("attendees").ContentLink.ToString());
            providerValues.Add(ContentProviderElement.CapabilitiesString, "Create,Edit,Delete,Search");

            // initialize and register the provider
            attendeeProvider.Initialize(AttendeeProvider.Key, providerValues);
            var providerManager = context.Locate.Advanced.GetInstance<IContentProviderManager>();
            providerManager.ProviderMap.AddProvider(attendeeProvider);
        }


        public Attendee ConvertToAttendee(Person person)
        {
            ContentType type = ContentTypeRepository.Load(typeof(Attendee));
            Attendee attendee =
                ContentFactory.CreateContent(type, new BuildingContext(type)
                {
                // as this is a flat structure, we set the parent to the provider's EntryPoint
                // by setting this in the Buildingcontext, access rights will also be inherited
                Parent = DataFactory.Instance.Get<ContentFolder>(EntryPoint),
                }) as Attendee;

            // make sure the content will be visible for all users
            attendee.Status = VersionStatus.Published;
            attendee.IsPendingPublish = false;
            attendee.StartPublish = DateTime.Now.Subtract(TimeSpan.FromDays(14));

            // This part is a bit tricky. IdentityMappingService is used in order to create the ContentReference and content GUID. 
            // The only unique property on the person object is the e-mail, so that will be used as the identifier.
            // First, create an external identifier based on the person's e-mail
            Uri externalId = MappedIdentity.ConstructExternalIdentifier(ProviderKey, person.Email);
            // then, invoke IdentityMappingService's Get with the externalId.
            // Make sure Get is invoked with the second parameter ('createMissingMapping') set to true. This will create a new mapping if no existing mapping is found
            MappedIdentity mappedContent = IdentityMappingService.Service.Get(externalId, true);
            attendee.ContentLink = mappedContent.ContentLink;
            attendee.ContentGuid = mappedContent.ContentGuid;

            // and then the properties from the person objects
            attendee.Title = person.Title;
            attendee.Name = person.Name;
            attendee.Company = person.Company;
            attendee.Email = person.Email;

            // make the content read only
            attendee.MakeReadOnly();
            return attendee;
        }
    }

    public class Person
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
    }

    public interface IPersonService
    {
        Person GetPersonByEmail(string email);
        IEnumerable<Person> GetAll();
        void UpdatePerson(string originalEmail, string newEmail, string title, string name, string company);
        void CreatePerson(Person person);
        IEnumerable<Person> Search(string searchQuery);
        void Delete(string email);
    }

    public class PersonService : IPersonService
    {
        public  Person GetPersonByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            var persons=new List<Person>()
            {
                new Person()
                {
                    Email = "xx@xx.com",
                    Company = "Company",
                    Name = "Name",
                    Title = "Title"
                }
            };

            return persons.AsEnumerable();
        }

        public void UpdatePerson(string originalEmail, string newEmail, string title, string name, string company)
        {
            throw new NotImplementedException();
        }

        public void CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Search(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public void Delete(string email)
        {
            throw new NotImplementedException();
        }
    }

    [ContentType(GUID = "0D4A8F04-8337-4A59-882E-F39617E5D434")]
    public class Attendee : ContentBase
    {
        [EmailAddress]
        [Required]
        public virtual string Email { get; set; }
        public virtual string Title { get; set; }
        public virtual string Company { get; set; }
    }


    /*[ServiceConfiguration(typeof(IContentRepositoryDescriptor))]
    public class AttendeeRepositoryDescriptor : ContentRepositoryDescriptorBase
    {
        protected Injected<IContentProviderManager> ContentProviderManager { get; set; }
        public override string Key { get { return AttendeeProvider.Key; } }

        public override string Name { get { return "Attendees"; } }

        public override IEnumerable<ContentReference> Roots { get { return new[] { ContentProviderManager.Service.GetProvider(AttendeeProvider.Key).EntryPoint }; } }

        public override IEnumerable<Type> ContainedTypes { get { return new[] { typeof(Attendee) }; } }

        public override IEnumerable<Type> MainNavigationTypes { get { return new[] { typeof(ContentFolder) }; } }

        public override IEnumerable<Type> CreatableTypes { get { return new[] { typeof(Attendee) }; } }
    }#1#

    [Component]
    public class AttendeeComponent : ComponentDefinitionBase
    {
        public AttendeeComponent() : base("epi-cms.widget.HierarchicalList")
        {
            Categories = new string[] { "content" };
            Title = "Attendees";
            Description = "All the attendees at the techforum! Displayed neatly in the assets pane";
            SortOrder = 1000;
            PlugInAreas = new[] { PlugInArea.AssetsDefaultGroup };
            Settings.Add(new Setting("repositoryKey", AttendeeProvider.Key));
        }
    }


}*/