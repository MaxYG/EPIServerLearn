using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Learning.DynamicDataStore;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.Data.Dynamic.Providers;
using EPiServer.Data.Dynamic.Providers.Internal;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class DDSController :  PageControllerBase<Dds>
    {
        public ActionResult Index(Dds currentPage)
        {
            var model = new DdsViewModel(currentPage);
            SetStoreReMappingViewModel(model);
            SetGlobalTypeToStoreMappingViewModel(model);
            SetUsingLocalTypeToStoreMappingViewModel(model);
            //UsingGlobalStoreToTableMapping(model);

            return View("/Views/Learning/Dds/Index.cshtml", model);
        }

        private void UsingGlobalStoreToTableMapping(DdsViewModel model)
        {
            var provider = DataStoreProvider.CreateInstance();
            if (!(provider is DbDataStoreProvider))
            {
                throw new NotSupportedException("the sample required a database providre");
            }

           /* using (IDbCommand cmd=((DbDataStoreProvider)provider).CreateCommand())
            {
                cmd.CommandText = CustomBigTable.SqlCreateTable;
                cmd.ExecuteNonQuery();
            }*/

            try
            {
                GlobalTypeToStoreMap.Instance.Add(typeof (Person), "People");

                var parameters=new StoreDefinitionParameters();
                parameters.TableName = CustomBigTable.TableStorageName;
                GlobalStoreDefinitionParametersMap.Instance.Add("People", parameters);

                Person p = new Person()
                {
                    FirstName = "Tom",
                    LastName = "Yang",
                    DateOfBirth = new DateTime(1973, 05, 25),
                    Friends = new List<Person>()
                    {
                        new Person()
                        {
                            FirstName = "haha",
                            LastName = "hhh"
                        }
                    },
                    Associates = new List<Person>()
                    {
                        new Person()
                        {
                            FirstName = "hehe",
                            LastName = "eee"
                        }
                    }
                };

                parameters.ColumnNamesMap.Add("FirstName","String02");
                var store = DynamicDataStoreFactory.Instance.CreateStore("People", typeof (Person));
                store.Save(p);

                model.UsingGlobalStoreToTableMappingViewModel = store.Items<Person>().ToList();
            }
            finally 
            {
            }
        }

        private string MapStore(string propertyname, object propertyvalue)
        {
            if (propertyname== "ChiefExecutive")
            {
                return "Executive";
            }
            if (propertyname== "Employees")
            {
                return "Employee";
            }

            return null;
        }

        public void SetUsingLocalTypeToStoreMappingViewModel(DdsViewModel model)
        {
            Company company = new Company()
            {
                Name = "company name",
                Address = new Address()
                {
                    Line1 = "45 West 22nd Street",
                    City = "New Cargo"
                },
                ChiefExecutive = new Person()
                {
                    FirstName = "Tom",
                    LastName = "Yang"
                },
                Employees = new List<Person>()
                 {
                     new Person()
                     {
                         FirstName = "Fred",
                         LastName = "Elderino"
                     },
                     new Person()
                     {
                         FirstName = "Janet",
                         LastName = "Wuvven"
                     }
                 }
            };

            DynamicDataStoreFactory.Instance.DeleteStore("company", true);
            var storeLocalType = DynamicDataStoreFactory.Instance.CreateStore("company", typeof(Company));

            Identity id = storeLocalType.Save(company, new TypeToStoreMapper(MapStore));
            storeLocalType.Save(company, (propertyName, propertyValue) =>
            {
                if (propertyValue == company.ChiefExecutive)
                {
                    return "Executive";
                }
                if (propertyValue is Person && company.Employees.Contains((Person)propertyValue))
                {
                    return "Employee";
                }

                return null;
            });
            

            var companyInfo=DynamicDataStoreFactory.Instance.GetStore("company");
            
            
            
            model.UsingLocalTypeToStoreMappingExecutiveViewModel = DynamicDataStoreFactory.Instance.GetStore("Executive").Items<Person>().ToList();
            model.UsingLocalTypeToStoreMappingEmployeeViewModel = DynamicDataStoreFactory.Instance.GetStore("Employee").Items<Person>().ToList();

            //method1
            var bbb = companyInfo.Load<Company>(id);
            var emploies = bbb.Employees;

            ////method2
            var propertyBag = companyInfo.LoadAsPropertyBag(id);
            var emploiesccc=(List<Person>)propertyBag["Employees"];

            model.UsingLocalTypeToStoreMappingAddressViewModel = string.Join("   ", emploiesccc.Select(x=>x.FirstName+" "+x.LastName));

        }

        public void SetGlobalTypeToStoreMappingViewModel(DdsViewModel model)
        {
            Person person = new Person()
            {
                FirstName = "Jack",
                LastName = "Williams",
                DateOfBirth = new DateTime(1973, 05, 25),
                Address = new Address()
                {
                    Line1 = "AnyStreet",
                    City = "AnyCity"
                },
                Friends = new List<Person>()
                {
                    new Person()
                    {
                        FirstName = "Andy",
                        LastName = "Collins"
                    }
                },
                Associates = new List<Person>()
                {
                    new Person()
                    {
                        FirstName = "Mary",
                        LastName = "Forde"
                    }
                }
            };

            GlobalTypeToStoreMap.Instance.Remove(typeof(Person));
            GlobalTypeToStoreMap.Instance.Remove(typeof(Address));
            GlobalTypeToStoreMap.Instance.Add(typeof(Person), "People");
            GlobalTypeToStoreMap.Instance.Add(typeof(Address), "Addresses");
            DynamicDataStoreFactory.Instance.DeleteStore("People",true);
            var storeGlobal = DynamicDataStoreFactory.Instance.CreateStore("People", typeof(Person));
            storeGlobal.Save(person);

            model.UsingGlobalTypeToStoreMappingViewModel = storeGlobal.Items<Person>().ToList();
            model.UsingGlobalTypeToStoreMappingAddressViewModel = DynamicDataStoreFactory.Instance.GetStore(typeof(Address)).Items<Address>().ToList();
        }

        public void SetStoreReMappingViewModel(DdsViewModel model)
        {
            var typeBag = new Dictionary<string, Type>();
            typeBag.Add("A", typeof(string));
            typeBag.Add("B", typeof(long));
            typeBag.Add("C", typeof(DateTime));
            typeBag.Add("D", typeof(float));

            DynamicDataStoreFactory.Instance.DeleteStore("MyStore", true);
            var store = DynamicDataStoreFactory.Instance.CreateStore("MyStore", typeBag);

            StoreDefinition storeDefinition = StoreDefinition.Get("MyStore");
            IList<PropertyMap> mappings = storeDefinition.ActiveMappings.ToArray();

            typeBag.Add("E", typeof(Guid));
            storeDefinition.Remap(typeBag);
            storeDefinition.CommitChanges();



            model.StoreReMappingViewModel = new DdsViewModel.StoreReMappingView()
            {
                OldPropertyCount = mappings.Count,
                OldPropertyNames = string.Join(",", mappings.Select(x => x.PropertyName).ToList()),
                OldPropertyTypes = string.Join(",  ", mappings.Select(x => x.PropertyType).ToList())
            };


            IList<PropertyMap> newMappings = storeDefinition.ActiveMappings.ToArray();
            model.StoreReMappingViewModel.NewPropertyCount = newMappings.Count;
            model.StoreReMappingViewModel.NewPropertyNames = string.Join(",", newMappings.Select(x => x.PropertyName).ToList());
            model.StoreReMappingViewModel.NewPropertyTypes = string.Join(",  ", newMappings.Select(x => x.PropertyType).ToList());

            storeDefinition.RenameProperty("E", "F");
            storeDefinition.CommitChanges();
            IList<PropertyMap> renameMappings = storeDefinition.ActiveMappings.ToArray();
            model.StoreReMappingViewModel.RenamePropertyCount = renameMappings.Count;
            model.StoreReMappingViewModel.RenamePropertyNames = string.Join(",", renameMappings.Select(x => x.PropertyName).ToList());
            model.StoreReMappingViewModel.RenamePropertyTypes = string.Join(",  ", renameMappings.Select(x => x.PropertyType).ToList());

            typeBag["B"] = typeof(int);
            storeDefinition.Remap(typeBag);
            storeDefinition.CommitChanges();
            IList<PropertyMap> renameTypeMappings = storeDefinition.ActiveMappings.ToArray();
            model.StoreReMappingViewModel.RenameTypePropertyCount = renameTypeMappings.Count;
            model.StoreReMappingViewModel.RenameTypePropertyNames = string.Join(",", renameTypeMappings.Select(x => x.PropertyName).ToList());
            model.StoreReMappingViewModel.RenameTypePropertyTypes = string.Join(",  ", renameTypeMappings.Select(x => x.PropertyType).ToList());

            PropertyBag propertyBag = new PropertyBag();
            propertyBag.Add("B", int.MaxValue);
            store.Save(propertyBag);

            model.StoreReMappingViewModel.PropertyBValue = propertyBag.First(x => x.Key == "B").Value.ToString();

            typeBag["B"] = typeof(short);

            try
            {
                storeDefinition.Remap(typeBag);
                storeDefinition.CommitChanges();
            }
            catch (InvalidOperationException e)
            {
                model.StoreReMappingViewModel.ConvertTypeError = e.Message;
            }
        }
    }

    public class CustomBigTable
    {
        public static string TableStorageName = "tblCustomBigTable";
        public static string OracleCreateTable = " BEGIN EXECUTE IMMEDIATE 'CREATE TABLE " + TableStorageName +
                                        " (PKID         NUMBER(38) not null, " +
                                        " ROWNUMBER    NUMBER(11) default (1) not null,  " +
                                        " STORENAME    NVARCHAR2(128) not null,  " +
                                        " ITEMTYPE     NVARCHAR2(512) not null,  " +
                                        " BOOLEAN01    NUMBER(1),  " +
                                        " INTEGER01    NUMBER(11), " +
                                        " INTEGER02    NUMBER(11),  " +
                                        " LONG01       NUMBER(38),  " +
                                        " DATETIME01   TIMESTAMP(3), " +
                                        " GUID01       RAW(16),  " +
                                        " FLOAT01      BINARY_DOUBLE,  " +
                                        " STRING01     NCLOB,  " +
                                        " STRING02     NCLOB,  " +
                                        " STRING03     NCLOB,  " +
                                        " BINARY01     BLOB)';" +
                                        " EXECUTE IMMEDIATE 'alter table " + TableStorageName +
                                        " add constraint PK_" + TableStorageName + " primary key (PKID,ROWNUMBER)';  " +
                                        " EXECUTE IMMEDIATE 'alter table " + TableStorageName +
                                        " add constraint FK_" + TableStorageName + "IDENT foreign key (PKID)  " +
                                        " references TBLBIGTABLEIDENTITY (PKID)';  " +
                                        " EXECUTE IMMEDIATE 'alter table " + TableStorageName +
                                        " add constraint CH_" + TableStorageName +
                                        " check (ROWNUMBER>=1)';END;";

        public static string SqlCreateTable = "create table [dbo].[" + TableStorageName + "] " +
                                        " ([pkId] bigint not null, " +
                                        " [Row] int not null default(1) constraint CH_" + TableStorageName + " check ([Row]>=1), " +
                                        " [StoreName] nvarchar(128) not null, " +
                                        " [ItemType] nvarchar(512) not null, " +
                                        " [Boolean01] bit null, " +
                                        " [Integer01] int null, " +
                                        " [Integer02] int null, " +
                                        " [Long01] bigint null, " +
                                        " [DateTime01] datetime null, " +
                                        " [Guid01] uniqueidentifier null, " +
                                        " [Float01] float null, " +
                                        " [String01] nvarchar(max) null, " +
                                        " [String02] nvarchar(max) null, " +
                                        " [String03] nvarchar(max) null, " +
                                        " [Binary01] varbinary(max) null, " +
                                        " constraint [PK_" + TableStorageName + "] primary key clustered([pkId],[Row]), " +
                                        " constraint [FK_" + TableStorageName + "_tblBigTableIdentity] foreign key ([pkId]) " +
                                        " references [tblBigTableIdentity]([pkId]))";

        public static string SqlDeleteTable = "DROP TABLE " + TableStorageName;
        public static string OracleDeleteTable = "BEGIN EXECUTE IMMEDIATE 'DROP TABLE " + TableStorageName + "';END;";
    }
}