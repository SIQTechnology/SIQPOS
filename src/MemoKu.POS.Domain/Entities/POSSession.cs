using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Domain.Entities
{
    public class POSSession
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public DateTime OpenDate { get; private set; }
        public DateTime CloseDate { get; private set; }
        public SessionState SessionState { get; private set; }

        private POSSession() { }

        public POSSession(Guid id, string userName, DateTime openDate, DateTime closeDate, SessionState state)
        {
            this.Id = id;
            this.UserName = userName;
            this.OpenDate = openDate;
            this.CloseDate = closeDate;
            this.SessionState = state;
        }

        public POSSession(string userName)
        {
            var date = DateTime.Now;
            this.Id = Guid.NewGuid();
            this.UserName = userName;
            this.OpenDate = date;
            this.CloseDate = date;
            this.SessionState = SessionState.Open;
        }

        internal void Close()
        {
            this.SessionState = SessionState.Closed;
            this.CloseDate = DateTime.Now;
        }
    }
}
