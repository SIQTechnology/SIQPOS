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
    class when_add_three_item_if_shopping_cart_have_tax_and_charge : behave_like_item_added_by_tax_and_service_charge
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

        It service_charge_amount_should_equals_1200 = () =>
        {
            _sc.Summary.ChargeAmount.Amount.ShouldEqual(1200);
        };

        It tax_amount_should_equals_1320 = () =>
        {
            _sc.Summary.TaxAmount.Amount.ShouldEqual(1320);
        };

        It net_amount_shopping_cart_should_be_equals_14520 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(14520);
        };
    }
}
