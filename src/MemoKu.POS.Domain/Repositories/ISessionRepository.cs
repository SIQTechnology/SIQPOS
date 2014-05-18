using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain.Entities;

namespace MemoKu.POS.Domain.Repository
{
    public interface ISessionRepository
    {
        POSSession GetSessionOpened(string userName);
        void Save(POSSession session);
        DateTime GetLastCloseDate(string userName);
        void Update(POSSession session);
    }
}
