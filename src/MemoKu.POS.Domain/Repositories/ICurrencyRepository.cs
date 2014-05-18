using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        Currency Default();
    }
}
