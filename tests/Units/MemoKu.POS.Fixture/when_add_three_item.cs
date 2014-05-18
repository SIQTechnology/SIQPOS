using System;
using System.Linq;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.ValueObjects;
using MemoKu.POS.Fixture.Contexts;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    class when_add_three_item : behave_like_item_added
    {
        static Product product;
        static Guid itemId_new;
        Establish ctx = () =>
        {
            product = new Product(Guid.NewGuid(), "Fruit Tea", "002", 4000);
        };

        Because of = () =>
        {
            itemId_new = _sc.AddItem(product, DiscountRate.None);
        };

        It item_should_be_added = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_new)).ShouldNotBeNull();
        };

        It qty_item_added_should_be_equals_1 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_new)).Quantity.ShouldEqual(1);
        };

        It price_item_added_should_be_equals_4000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_new)).Product.Price.ShouldEqual(4000);
        };

        It net_amount_shopping_cart_should_be_equals_12000 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(12000);
        };
    }
}
