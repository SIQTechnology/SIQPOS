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
    public class when_change_price : behave_like_item_added
    {
        Because of = () =>
        {
            _sc.ChangePrice(itemId, 6000);
        };

        It price_item_should_equals_6000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Product.Price.ShouldEqual(6000);
        };

        It total_amount_item_should_equals_6000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).AmountAfterDiscount.ShouldEqual(6000);
        };

        It net_amount_shopping_cart_should_equals_9000 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(9000);
        };
    }
}
