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
    public class when_increase_quantity : behave_like_item_added
    {
        Because of = () =>
        {
            _sc.IncreaseQuantity(itemId);
        };

        It quantity_item_should_equals_2 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Quantity.ShouldEqual(2);
        };

        It total_amount_item_should_equals_10000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountAfterDiscount.ShouldEqual(10000);
        };

        It net_amount_shopping_cart_should_equals_13000 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(13000);
        };
    }
}
