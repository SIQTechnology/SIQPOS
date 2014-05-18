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
    class when_add_three_item_with_discount_total : behave_like_item_added
    {
        static Product product;
        static Guid itemId_new;
        Establish ctx = () =>
        {
            _sc.ChangeDiscountTotal(new DiscountRate(DiscountType.Percent, 10));
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

        It shared_discount_amount_first_item_should_equals_500 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).SharedDiscountAmount.ShouldEqual(500);
        };

        It net_amount_first_item_should_equals_4500 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).NetAmount.ShouldEqual(4500);
        };

        It shared_discount_amount_second_item_should_equals_300 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_2)).SharedDiscountAmount.ShouldEqual(300);
        };

        It net_amount_second_item_should_equals_2700 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_2)).NetAmount.ShouldEqual(2700);
        };

        It shared_discount_amount_three_item_should_equals_400 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_new)).SharedDiscountAmount.ShouldEqual(400);
        };

        It net_amount_three_item_should_equals_3600 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId_new)).NetAmount.ShouldEqual(3600);
        };

        It net_amount_shopping_cart_should_be_equals_10800 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(10800);
        };
    }
}
