using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Mvc;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Mvc.Modes;
using MemoKu.Test.Modes.Scan.context;

namespace MemoKu.Test.Modes.Scan
{
    class when_key_down_pressed : behave_like_item_added
    {
        Establish context = () =>
        {
            scanMode.OnKeyUpPress();
        };

        Because of = () =>
        {
            scanMode.OnKeyDownPress();
        };

        It item_qty_shopping_cart_should_equals_1 = () =>
        {
            Context.Session.ShoppingCart.Items.FirstOrDefault(i => i.Product.Id.Equals(product_1.Id)).Quantity.ShouldEqual(1);
        };

        It net_amount_shopping_cart_should_equals_2000 = () =>
        {
            Context.Session.ShoppingCart.NetAmount.ShouldEqual(2000);
        };
    }
}
