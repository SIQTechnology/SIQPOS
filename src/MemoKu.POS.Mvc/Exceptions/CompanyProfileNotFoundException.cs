using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Mvc.Exceptions
{
    public class CompanyProfileNotFoundException : Exception
    {
        public CompanyProfileNotFoundException()
            : base("Company Profile not found, please re-synchronize")
        {
            base.Data.Add("ShowSyncDialog", true);
        }
    }
}
