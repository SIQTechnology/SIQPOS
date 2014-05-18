using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.ValueObjects;
using MemoKu.POS.Fixture.Contexts;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    public class when_given_discount_total_by_percent : behave_like_item_added_by_tax_and_service_charge
    {
        Because of = () =>
        {
            _sc.ChangeDiscountTotal(new DiscountRate(DiscountType.Percent, 10));
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

        It subtotal_should_equals_8000 = () =>
        {
            _sc.Summary.SubTotal.ShouldEqual(8000);
        };

        It discount_total_percent_should_equals_10 = () =>
        {
            _sc.Summary.DiscountTotalAmount.Percent.ShouldEqual(10);
        };

        It discount_total_amount_should_equals_800 = () =>
        {
            _sc.Summary.DiscountTotalAmount.Amount.ShouldEqual(800);
        };

        It charge_percent_should_equals_10 = () =>
        {
            _sc.Summary.ChargeAmount.Percent.ShouldEqual(10);
        };

        It charge_amount_should_equals_720 = () =>
        {
            _sc.Summary.ChargeAmount.Amount.ShouldEqual(720);
        };

        It tax_percent_should_equals_10 = () =>
        {
            _sc.Summary.TaxAmount.Percent.ShouldEqual(10);
        };

        It tax_amount_should_equals_792 = () =>
        {
            _sc.Summary.TaxAmount.Amount.ShouldEqual(792);
        };

        It net_amount_shopping_cart_should_equals_8712 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(8712);
        };
    }
}
