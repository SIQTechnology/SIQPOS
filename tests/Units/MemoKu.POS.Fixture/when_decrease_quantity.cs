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
    public class when_decrease_quantity : behave_like_item_added
    {
        Establish ctx = () =>
        {
            _sc.ChangeQuantity(itemId, 5);
        };

        Because of = () =>
        {
            _sc.DecreaseQuantity(itemId);
        };

        It quantity_item_should_equals_4 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Quantity.ShouldEqual(4);
        };

        It total_amount_item_should_equals_20000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountAfterDiscount.ShouldEqual(20000);
        };

        It net_amount_shopping_cart_should_equals_23000 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(23000);
        };
    }
}
