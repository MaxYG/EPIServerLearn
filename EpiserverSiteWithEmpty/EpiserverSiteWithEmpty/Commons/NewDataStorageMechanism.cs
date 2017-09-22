using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using EPiServer.Data.Dynamic;
using EPiServer.Forms.Core.Data;
using EPiServer.Forms.Core.Models;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Commons
{
    public class NewDataStorageMechanism
    {
    }

    [ServiceConfiguration(typeof(IPermanentStorage))]
    public class YourDataStorage : PermanentStorage
    {
        public YourDataStorage()
        {
        }

        public override Guid SaveToStorage(FormIdentity formIden, Submission submission)
        {
            throw new NotImplementedException();
        }

        public override Guid UpdateToStorage(Guid formSubmissionId, FormIdentity formIden, Submission submission)
        {
            throw new NotImplementedException();
        }

        public override void Delete(FormIdentity formIden, string submissionId)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PropertyBag> LoadSubmissionFromStorage(FormIdentity formIden, DateTime beginDate, DateTime endDate,
            bool finalizedOnly = false)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<PropertyBag> LoadSubmissionFromStorage(FormIdentity formIden, string[] submissionIds)
        {
            throw new NotImplementedException();
        }
    }
}