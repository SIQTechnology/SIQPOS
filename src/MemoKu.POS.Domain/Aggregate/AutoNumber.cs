using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.Aggregate
{
    public class AutoNumber
    {
        public string OrganizationId { get; private set; }
        public string ClientId { get; private set; }
        public DateTime Date { get; private set; }
        public long Number { get; set; }

        private AutoNumber() { }

        public AutoNumber(string organizationId, string clientId, DateTime date)
        {
            this.OrganizationId = organizationId;
            this.ClientId = clientId;
            this.Date = date;
        }

        public AutoNumber(string organizationId, string clientId, DateTime date, long number)
            : this(organizationId, clientId, date)
        {
            this.Number = 0;
        }

        public void Next()
        {
            this.Number++;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}{3}", OrganizationId, ClientId, Date.ToString("yyyyMMdd"), Number.ToString("0000"));
        }
    }
}
