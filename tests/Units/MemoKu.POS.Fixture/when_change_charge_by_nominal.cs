using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.ValueObjects;
using MemoKu.POS.Fixture.Contexts;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    public class when_change_charge_by_nominal : behave_like_item_added_by_tax_and_service_charge
    {
        Because of = () =>
        {
            _sc.ChangeCharge(new ChargeRate(ChargeType.Nominal, 4000));
        };

        It subtotal_should_equals_8000 = () =>
        {
            _sc.Summary.SubTotal.ShouldEqual(8000);
        };

        It charge_percent_should_equals_50 = () =>
        {
            _sc.Summary.ChargeAmount.Percent.ShouldEqual(50);
        };

        It charge_amount_should_equals_4000 = () =>
        {
            _sc.Summary.ChargeAmount.Amount.ShouldEqual(4000);
        };

        It tax_percent_should_equals_10 = () =>
        {
            _sc.Summary.TaxAmount.Percent.ShouldEqual(10);
        };

        It tax_amount_should_equals_1200 = () =>
        {
            _sc.Summary.TaxAmount.Amount.ShouldEqual(1200);
        };

        It net_amount_shopping_cart_should_equals_13200 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(13200);
        };
    }
}
