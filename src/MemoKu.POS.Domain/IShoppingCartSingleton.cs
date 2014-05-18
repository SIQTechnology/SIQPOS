using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Entities;

namespace MemoKu.POS.Domain
{
    public interface IShoppingCartSingleton
    {
        ShoppingCart ShoppingCart { get; }
        void SetSession(POSSession session);
        void SetShoppingCart(ShoppingCart sc);
    }
}
