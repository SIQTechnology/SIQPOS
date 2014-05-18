using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Mvc;
using MemoKu.POS.Mvc.Controller;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Mvc.Modes;
using MemoKu.Test.context;

namespace MemoKu.Test
{
    [Subject("Add Item")]
    public class when_add_item : test_base_mode
    {
        static ScanMode scanMode;
        Establish ctx = () =>
        {
            scanMode = new ScanMode(mainCtrl, mainView, modeCtrl, searchPartView);
        };

        Because of = () =>
        {
            scanMode.OnKeyEnterPress("001");
        };

        It item_shopping_cart_should_added = () =>
        {
            Context.Session.ShoppingCart.Items.FirstOrDefault(i => i.Product.Id.Equals(product_1.Id)).ShouldNotBeNull();
        };

        It item_qty_shopping_cart_should_equals_1 = () =>
        {
            Context.Session.ShoppingCart.Items.FirstOrDefault(i => i.Product.Id.Equals(product_1.Id)).Quantity.ShouldEqual(1);
        };

        It net_amount_shopping_cart_should_equals_2000 = () =>
        {
            Context.Session.ShoppingCart.NetAmount.ShouldEqual(2000);
        };

        It should_be_item_selected = () =>
        {
            Context.Session.CurrentItemId.ShouldNotEqual(Guid.Empty);
        };
    }
}
