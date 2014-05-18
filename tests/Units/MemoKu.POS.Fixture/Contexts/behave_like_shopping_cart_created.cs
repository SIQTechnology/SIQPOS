using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Fixture.Contexts
{
    [Subject(typeof(ShoppingCart))]
    public class behave_like_shopping_cart_created
    {
        protected static string organizationId;
        protected static string clientId;
        protected static ShoppingCart _sc;
        Establish ctx = () =>
        {
            organizationId = "siqpos";
            clientId = "kasir1";
            var ccy = new Currency("IDR", "Rupiah", 2);
            var taxRate = TaxRate.None;
            var chargeRate = ChargeRate.None;
            _sc = new ShoppingCart(Guid.NewGuid(), "Denny Wu", ccy, taxRate, chargeRate);
        };
    }
}
