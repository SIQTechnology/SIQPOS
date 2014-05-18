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
    class when_key_up_pressed : behave_like_item_added
    {
        Because of = () =>
        {
            scanMode.OnKeyUpPress();
        };

        It item_qty_shopping_cart_should_equals_2 = () =>
        {
            Context.Session.ShoppingCart.Items.FirstOrDefault(i => i.Product.Id.Equals(product_1.Id)).Quantity.ShouldEqual(2);
        };

        It net_amount_shopping_cart_should_equals_4000 = () =>
        {
            Context.Session.ShoppingCart.NetAmount.ShouldEqual(4000);
        };
    }
}
