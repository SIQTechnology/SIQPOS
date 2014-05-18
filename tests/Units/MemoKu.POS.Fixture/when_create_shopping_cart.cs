using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    public class when_create_shopping_cart
    {
        static ShoppingCart sc;
        static Currency ccy;
        static TaxRate taxRate;
        static ChargeRate chargeRate;
        Establish ctx = () =>
        {
            ccy = new Currency("IDR", "Rupiah", 2);
            taxRate = new TaxRate("PPN","Pajak Penghasilan Negara",10);
            chargeRate = new ChargeRate(ChargeType.Percent, 10);
        };

        Because of = () =>
        {
            sc = new ShoppingCart(Guid.NewGuid(), "Denny Wu", ccy, taxRate, chargeRate);
        };

        It shopping_cart_should_be_created = () =>
        {
            sc.ShouldNotBeNull();
        };

        It discount_total_percent_should_equals_0 = () =>
        {
            sc.Summary.DiscountTotalAmount.Percent.ShouldEqual(0);
        };

        It net_amount_shopping_cart_should_equals_0 = () =>
        {
            sc.Summary.NetAmount.ShouldEqual(0);
        };

        It charge_should_equals_10_percent = () =>
        {
            sc.Summary.ChargeAmount.Percent.ShouldEqual(10);
        };

        It tax_should_equals_10_percent = () =>
        {
            sc.Summary.TaxAmount.Percent.ShouldEqual(10);
        };
    }
}
