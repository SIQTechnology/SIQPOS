using System.Linq;
using Machine.Specifications;
using MemoKu.POS.Mvc;
using MemoKu.Test.Modes.Scan.context;

namespace MemoKu.Test.Modes.Scan
{
    class when_enter_key_press_for_increase_expression : behave_like_item_added
    {
        Because of = () =>
        {
            scanMode.OnKeyEnterPress("+5");
        };

        It item_qty_shopping_cart_should_equals_6 = () =>
        {
            Context.Session.ShoppingCart.Items.FirstOrDefault(i => i.Product.Id.Equals(product_1.Id)).Quantity.ShouldEqual(6);
        };

        It net_amount_shopping_cart_should_equals_12000 = () =>
        {
            Context.Session.ShoppingCart.NetAmount.ShouldEqual(12000);
        };
    }
}
