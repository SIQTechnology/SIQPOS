using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Fixture.Contexts;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    public class when_change_pay_with_cash : behave_like_item_added
    {
        Because of = () =>
        {
            _sc.Pay(10000, (date) =>
            {
                return date.ToString("yyyyMMdd");
            });
        };

        It transactionNumber_should_generated = () =>
        {
            _sc.TransactionNumber.ShouldEqual(_sc.Date.ToString("yyyyMMdd"));
        };

        It payment_type_should_equals_cash = () =>
        {
            _sc.Payment.Type.ShouldEqual(Domain.ValueObjects.PaymentTypes.Cash);
        };

        It payment_amount_should_equals_10000 = () =>
        {
            _sc.Payment.PayAmount.ShouldEqual(10000);
        };

        It change_amount_should_equals_2000 = () =>
        {
            _sc.Payment.ChangeAmount.ShouldEqual(2000);
        };
    }
}
