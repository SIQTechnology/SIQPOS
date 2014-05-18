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
    public class when_change_discount_item_by_nominal : behave_like_item_added
    {
        Because of = () =>
        {
            _sc.ChangeDiscount(itemId, new DiscountRate(DiscountType.Nominal, 500));
        };

        It price_item_should_equals_5000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Product.Price.ShouldEqual(5000);
        };

        It amount_item_before_discount_should_equals_5000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountBeforeDiscount.ShouldEqual(5000);
        };

        It discount_percent_should_equals_10 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).DiscountAmount.Percent.ShouldEqual(10);
        };

        It discount_amount_should_equals_500 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).DiscountAmount.Amount.ShouldEqual(500);
        };

        It amount_item_after_discount_should_equals_4500 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountAfterDiscount.ShouldEqual(4500);
        };

        It amount_shared_discount_should_equals_0 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).SharedDiscountAmount.ShouldEqual(0);
        };

        It net_amount_shopping_cart_should_equals_7500 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(7500);
        };
    }
}
