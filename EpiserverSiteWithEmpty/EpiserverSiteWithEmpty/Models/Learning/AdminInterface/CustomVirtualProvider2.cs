using System.Security.Principal;
using EPiServer.Security;

namespace EpiserverSiteWithEmpty.Models.Learning.AdminInterface
{
    public class CustomVirtualProvider2Role:EPiServer.Security.VirtualRoleProviderBase
    {
        public override bool IsInVirtualRole(IPrincipal principal, object context)
        {
            IPrincipal user = PrincipalInfo.CurrentPrincipal;
            if (user.IsInRole("testtest") && user.IsInRole("Testing"))
            {
                return true;
            }
            return false;
        }
    }
}