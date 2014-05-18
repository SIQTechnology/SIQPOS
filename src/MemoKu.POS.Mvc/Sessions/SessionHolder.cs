using System;
using MemoKu.POS.Reporting.Models;

namespace MemoKu.POS.Mvc.Sessions
{
    public class SessionHolder : ShoppingCartSingleton
    {
        public POSUser POSUser { get; private set; }
        public CompanyProfile CompanyProfile { get; private set; }
        public Guid CurrentItemId { get; private set; }

        public void SetPOSUser(POSUser posUser)
        {
            this.POSUser = posUser;
        }

        public void SetCompanyProfile(CompanyProfile companyProfile)
        {
            this.CompanyProfile = companyProfile;
        }

        public void SetCurrentItemId(Guid itemId)
        {
            this.CurrentItemId = itemId;
        }
    }
}
