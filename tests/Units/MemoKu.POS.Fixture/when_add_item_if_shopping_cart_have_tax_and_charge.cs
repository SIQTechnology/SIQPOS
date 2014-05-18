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
    public class when_add_item_if_shopping_cart_have_tax_and_charge : behave_like_shopping_cart_has_been_created_by_tax_and_service_charge
    {
        static Product product;
        static Guid itemId;
        Establish ctx = () =>
        {
            product = new Product(Guid.NewGuid(), "MiZone", "001", 5000);
        };

        Because of = () =>
        {
            itemId = _sc.AddItem(product, DiscountRate.None);
        };

        It item_should_be_added = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).ShouldNotBeNull();
        };

        It qty_item_added_should_be_equals_1 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Quantity.ShouldEqual(1);
        };

        It price_item_added_should_be_equals_5000 = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).Product.Price.ShouldEqual(5000);
        };

        It service_charge_amount_should_equals_500 = () =>
        {
            _sc.Summary.ChargeAmount.Amount.ShouldEqual(500);
        };

        It tax_amount_should_equals_550 = () =>
        {
            _sc.Summary.TaxAmount.Amount.ShouldEqual(550);
        };

        It net_amount_shopping_cart_should_be_equals_6050 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(6050);
        };
    }
}
