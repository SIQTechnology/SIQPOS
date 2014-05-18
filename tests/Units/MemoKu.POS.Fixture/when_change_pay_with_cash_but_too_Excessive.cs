using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Exceptions;
using MemoKu.POS.Fixture.Contexts;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    public class when_change_pay_with_cash_but_too_Excessive : behave_like_item_added
    {
        static Exception ex;
        Because of = () =>
        {
            ex = Catch.Exception(() => _sc.Pay(1100000, (date) =>
            {
                return date.ToString("yyyyMMdd");
            }));
        };

        It exception_should_equals_PaymentAmountTooExcessiveException = () =>
        {
            ex.GetType().ShouldEqual(typeof(PaymentAmountTooExcessiveException));
        };
    }
}
