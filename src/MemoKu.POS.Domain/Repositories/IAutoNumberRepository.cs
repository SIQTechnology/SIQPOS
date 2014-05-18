using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain.Aggregate;

namespace MemoKu.POS.Domain.Repositories
{
    public interface IAutoNumberRepository
    {
        AutoNumber Get(DateTime transactionDate);
        void Insert(AutoNumber autoNumber);
        void Update(AutoNumber autoNumber);
    }
}
