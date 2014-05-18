using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Reporting.Models
{
    public class POSUser
    {
        public const string POS_SUPERVISOR = "POSSupervisor";
        public const string POS_ADMIN = "POSAdmin";
        public const string POS_USER = "POSUser";

        public string Username { get; private set; }
        public string[] Roles { get; private set; }
        public string[] Rules { get; private set; }

        public POSUser(string username, string[] roles, string[] rules)
        {
            this.Username = username;
            this.Roles = roles;
            this.Rules = rules;
        }

        public bool IsSuperviser()
        {
            return Roles.Contains(POS_SUPERVISOR) || Roles.Contains(POS_ADMIN);
        }

        //public bool IsPOSUserAllowedTo(POSUserRules action)
        //{
        //    if (Roles.Contains(POS_ADMIN) || Roles.Contains(POS_SUPERVISOR)) return true;
        //    return Rules.Contains(action.ToString());
        //}
    }
}
