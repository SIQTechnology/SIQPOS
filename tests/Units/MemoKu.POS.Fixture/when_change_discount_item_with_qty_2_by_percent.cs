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
    public class when_change_discount_item_with_qty_2_by_percent : behave_like_item_added
    {
        Establish ctx = () =>
        {
            _sc.ChangeQuantity(itemId, 2);
        };

        Because of = () =>
        {
            _sc.ChangeDiscount(itemId, new DiscountRate(DiscountType.Percent, 10));
        };

        It price_item_should_equals_5000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Product.Price.ShouldEqual(5000);
        };

        It amount_item_before_discount_should_equals_10000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountBeforeDiscount.ShouldEqual(10000);
        };

        It discount_percent_should_equals_10 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).DiscountAmount.Percent.ShouldEqual(10);
        };

        It discount_amount_should_equals_1000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).DiscountAmount.Amount.ShouldEqual(1000);
        };

        It amount_item_after_discount_should_equals_9000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountAfterDiscount.ShouldEqual(9000);
        };

        It amount_shared_discount_should_equals_0 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).SharedDiscountAmount.ShouldEqual(0);
        };

        It net_amount_shopping_cart_should_equals_12000 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(12000);
        };
    }
}
