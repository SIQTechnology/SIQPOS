using System;
using MemoKu.POS.Domain.Entities;

namespace MemoKu.POS.Domain.Aggregate
{
    public class ItemRemoved : Item
    {
        public string RemoveBy { get; private set; }

        public ItemRemoved(string removeBy, Item item)
            : base(item.Product, item.Quantity, item.DiscountRate)
        {
            this.RemoveBy = removeBy;
        }
    }
}
