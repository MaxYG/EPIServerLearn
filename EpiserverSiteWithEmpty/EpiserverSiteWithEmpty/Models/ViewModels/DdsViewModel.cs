using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpiserverSiteWithEmpty.Models.Learning.DynamicDataStore;

namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public class DdsViewModel:IPageViewModel<Dds>
    {
        public DdsViewModel(Dds dds)
        {
            CurrentPage = dds;
        }
        public Dds CurrentPage { get; }
        public StoreReMappingView StoreReMappingViewModel { get; set; }
        public List<Person> UsingGlobalTypeToStoreMappingViewModel { get; set; }
        public List<Address> UsingGlobalTypeToStoreMappingAddressViewModel { get; set; }
        public List<Person> UsingLocalTypeToStoreMappingExecutiveViewModel { get; set; }
        public List<Person> UsingLocalTypeToStoreMappingEmployeeViewModel { get; set; }
        public string UsingLocalTypeToStoreMappingAddressViewModel { get; set; }
        public List<Person> UsingGlobalStoreToTableMappingViewModel { get; set; }

        public class StoreReMappingView
        {
            public int OldPropertyCount { get; set; }
            public string OldPropertyNames { get; set; }
            public string OldPropertyTypes { get; set; }
            public int NewPropertyCount { get; set; }
            public string NewPropertyNames { get; set; }
            public string NewPropertyTypes { get; set; }
            public int RenamePropertyCount { get; set; }
            public string RenamePropertyNames { get; set; }
            public string RenamePropertyTypes { get; set; }

            public int RenameTypePropertyCount { get; set; }
            public string RenameTypePropertyNames { get; set; }
            public string RenameTypePropertyTypes { get; set; }

            public string PropertyBValue { get; set; }

            public string ConvertTypeError { get; set; }

        }

    }
    public class Company
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Person ChiefExecutive { get; set; }
        public IEnumerable<Person> Employees { get; set; }
    }

    public class Person
    {
        public Guid Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public IEnumerable<string> OtherNames
        {
            get;
            set;
        }

        public Address Address
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public DateTime? DateOfDeath
        {
            get;
            set;
        }

        public IEnumerable<Person> Friends
        {
            get;
            set;
        }

        public IEnumerable<Person> Associates
        {
            get;
            set;
        }
        
    }

    public class Address
    {
        public Guid Id
        {
            get;
            set;
        }

        public string Line1
        {
            get;
            set;
        }

        public string Line2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string ZipCode
        {
            get;
            set;
        }
        
    }


}