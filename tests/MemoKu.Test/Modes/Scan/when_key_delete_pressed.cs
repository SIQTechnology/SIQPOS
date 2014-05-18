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
    class when_key_delete_pressed : behave_like_item_added
    {
        Because of = () =>
        {
            scanMode.OnKeyDeletePress();
        };

        It item_should_be_deleted = () =>
        {
            Context.Session.ShoppingCart.Items.Count.ShouldEqual(0);
        };

        It net_amount_shopping_cart_should_equals_0 = () =>
        {
            Context.Session.ShoppingCart.NetAmount.ShouldEqual(0);
        };

        It should_be_no_item_selected = () =>
        {
            Context.Session.CurrentItemId.ShouldEqual(Guid.Empty);
        };
    }
}
