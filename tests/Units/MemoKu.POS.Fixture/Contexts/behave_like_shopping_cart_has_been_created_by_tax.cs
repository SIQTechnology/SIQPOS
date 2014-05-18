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
    public class behave_like_shopping_cart_has_been_created_by_tax
    {
        protected static ShoppingCart _sc;
        Establish ctx = () =>
        {
            var ccy = new Currency("IDR", "Rupiah", 2);
            var taxRate = new TaxRate("PPN", "Pajak Penghasil Negara", 10);
            var chargeRate = ChargeRate.None;
            _sc = new ShoppingCart(Guid.NewGuid(), "Denny Wu", ccy, taxRate, chargeRate);
        };
    }
}
