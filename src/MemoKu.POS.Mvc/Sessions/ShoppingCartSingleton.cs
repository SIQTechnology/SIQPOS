using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Entities;

namespace MemoKu.POS.Mvc.Sessions
{
    public class ShoppingCartSingleton : IShoppingCartSingleton
    {
        public POSSession POSSession { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }

        public void SetSession(POSSession session)
        {
            this.POSSession = session;
        }

        public void SetShoppingCart(ShoppingCart sc)
        {
            this.ShoppingCart = sc;
        }
    }
}
