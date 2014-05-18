using System;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public double AmountBeforeDiscount { get; private set; }
        public DiscountRate DiscountRate { get; private set; }
        public DiscountAmount DiscountAmount { get; private set; }
        public double AmountAfterDiscount { get; private set; }
        public double SharedDiscountAmount { get; private set; }
        public double NetAmount { get; private set; }

        private Item()
        {
            this.Id = Guid.NewGuid();
        }

        internal Item(Product product, int quantity, DiscountRate discountRate)
            : this()
        {
            this.Product = product;
            this.Quantity = 1;
            this.DiscountRate = discountRate;
            Calculate();
        }

        internal void ChangeQuantity(int qty)
        {
            if (qty <= 0) return;
            this.Quantity = qty;
            Calculate();
        }

        internal void AddQuantity(int qty)
        {
            var currentQty = this.Quantity;
            if ((currentQty + qty) <= 0) return;
            this.Quantity += qty;
            Calculate();
        }

        internal void ChangePrice(double price)
        {
            this.Product.ChangePrice(price);
            Calculate();
        }

        internal void ChangeDiscount(DiscountRate discountRate)
        {
            this.DiscountRate = discountRate;
            Calculate();
        }

        internal void ChangeDiscountTotal(double subTotal, DiscountAmount discountTotal)
        {
            if (subTotal == 0d) return;
            this.SharedDiscountAmount = (AmountAfterDiscount / subTotal) * discountTotal;
            Calculate();
        }

        private void Calculate()
        {
            this.AmountBeforeDiscount = Product.Price * Quantity;
            this.DiscountAmount = DiscountRate.Apply(AmountBeforeDiscount, Quantity);
            this.AmountAfterDiscount = AmountBeforeDiscount - DiscountAmount.Amount;
            this.NetAmount = AmountAfterDiscount - SharedDiscountAmount;
        }
    }
}
