using System;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Fixture.Contexts
{
    [Subject(typeof(ShoppingCart))]
    public class behave_like_item_added : behave_like_shopping_cart_created
    {
        protected static Guid itemId;
        protected static Guid itemId_2;
        Establish ctx = () =>
        {
            var product = new Product(Guid.NewGuid(), "MiZone", "001", 5000);
            var product_2 = new Product(Guid.NewGuid(), "Teh Botol", "011", 3000);
            itemId = _sc.AddItem(product, DiscountRate.None);
            itemId_2 = _sc.AddItem(product_2, DiscountRate.None);
        };
    }
}
