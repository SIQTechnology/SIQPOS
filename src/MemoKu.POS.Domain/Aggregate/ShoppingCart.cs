using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.Exceptions;
using MemoKu.POS.Domain.ValueObjects;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Domain.Aggregate
{
    public class ShoppingCart
    {
        public Guid Id { get; private set; }
        public Guid SessionId { get; private set; }
        public string UserName { get; private set; }
        public string TransactionNumber { get; private set; }
        public Currency Currency { get; private set; }
        public List<Item> Items { get; private set; }
        public List<ItemRemoved> ItemsRemoved { get; private set; }
        public string Note { get; private set; }
        public DateTime Date { get; private set; }
        public Payment Payment { get; private set; }
        public Summary Summary { get; private set; }

        private ShoppingCart() { }

        public ShoppingCart(Guid sessionId, string userName, Currency currency, TaxRate taxRate, ChargeRate chargeRate)
        {
            this.Id = Guid.NewGuid();
            this.SessionId = sessionId;
            this.UserName = userName;
            this.Items = new List<Item>();
            this.ItemsRemoved = new List<ItemRemoved>();
            this.Date = DateTime.Now;
            this.Currency = currency;
            this.TransactionNumber = string.Empty;
            this.Note = string.Empty;
            this.Payment = new Payment(PaymentTypes.Cash, 0d, 0d);
            var chargeAmount = chargeRate.Apply(0d);
            var taxAmount = taxRate.Apply(0d);
            var discountAmount = DiscountRate.None.Apply(0d, 0);
            this.Summary = new Summary(taxAmount, discountAmount, chargeAmount, 0d);
        }

        #region Item Shopping Cart Method

        public Guid AddItem(Product product, DiscountRate discountRate)
        {
            Item item = GetItem(product);
            if (item.IsNull())
            {
                item = new Item(product, 1, discountRate);
                Items.Add(item);
            }
            else
                item.AddQuantity(1);
            CalculateSummary();
            return item.Id;
        }

        public void ChangeQuantity(Guid itemId, int qty)
        {
            var item = GetItem(itemId);
            item.ChangeQuantity(qty);
            CalculateSummary();
        }

        public void IncreaseQuantity(Guid itemId)
        {
            var item = GetItem(itemId);
            item.AddQuantity(1);
            CalculateSummary();
        }

        public void DecreaseQuantity(Guid itemId)
        {
            var item = GetItem(itemId);
            item.AddQuantity(-1);
            CalculateSummary();
        }

        public void DeleteItem(Guid itemId, string removeBy)
        {
            var item = GetItem(itemId);
            if (!IsExistsInItemRemoved(item))
            {
                var itemRemoved = new ItemRemoved(removeBy, item);
                ItemsRemoved.Add(itemRemoved);
            }
            Items.Remove(item);
            CalculateSummary();
        }

        public void ChangePrice(Guid itemId, double price)
        {
            var item = GetItem(itemId);
            item.ChangePrice(price);
            CalculateSummary();
        }

        public void ChangeDiscount(Guid itemId, DiscountRate discountRate)
        {
            var item = GetItem(itemId);
            item.ChangeDiscount(discountRate);
            CalculateSummary();
        }

        #endregion

        public void ChangeCharge(ChargeRate chargeRate)
        {
            var chargeAmount = chargeRate.Apply(Summary.SubTotal);
            this.Summary = new Summary(Summary.TaxAmount, Summary.DiscountTotalAmount, chargeAmount, Summary.SubTotal);
            CalculateCharge();
            CalculateTax();
        }

        public void ChangeDiscountTotal(DiscountRate discountTotalRate)
        {
            var discountTotalAmount = discountTotalRate.Apply(Summary.SubTotal, 1);
            foreach (Item item in Items)
            {
                item.ChangeDiscountTotal(Summary.SubTotal, discountTotalAmount);
            }
            this.Summary = new Summary(Summary.TaxAmount, discountTotalAmount, Summary.ChargeAmount, Summary.SubTotal);
            CalculateCharge();
            CalculateTax();
        }

        public void ChangeNote(string note)
        {
            this.Note = note;
        }

        public void Pay(double payAmount, Func<DateTime, string> autoNumberGenerator)
        {
            AssertPaymentAmountAcceptable(payAmount);
            var changeAmount = payAmount - Summary.NetAmount;
            this.Payment = new Payment(PaymentTypes.Cash, payAmount, changeAmount);
            this.TransactionNumber = autoNumberGenerator.Invoke(Date);
        }

        public bool HasItems()
        {
            return Items.Count > 0;
        }

        #region private method

        private void CalculateSummary()
        {
            var amountBeforeDiscount = Items.Sum(i => i.AmountAfterDiscount);
            this.Summary = new Summary(Summary.TaxAmount, Summary.DiscountTotalAmount, Summary.ChargeAmount, amountBeforeDiscount);
            CalculateSharedDiscount();
            CalculateCharge();
            CalculateTax();
        }

        private void CalculateSharedDiscount()
        {
            if (!Summary.DiscountTotalAmount.IsZero())
            {
                var discountTotalRate = new DiscountRate(DiscountType.Percent, Summary.DiscountTotalAmount.Percent);
                var discountTotalAmount = discountTotalRate.Apply(Summary.SubTotal, 1);
                this.Summary = new Summary(Summary.TaxAmount, discountTotalAmount, Summary.ChargeAmount, Summary.SubTotal);
                foreach (Item item in Items)
                {
                    item.ChangeDiscountTotal(Summary.SubTotal, discountTotalAmount);
                }
            }
        }

        private void CalculateCharge()
        {
            if (Summary.ChargeAmount.Percent > 0)
            {
                var chargeRate = new ChargeRate(ChargeType.Percent, Summary.ChargeAmount.Percent);
                var chargeAmount = chargeRate.Apply(Summary.SubTotal - Summary.DiscountTotalAmount);
                this.Summary = new Summary(Summary.TaxAmount, Summary.DiscountTotalAmount, chargeAmount, Summary.SubTotal);
            }
        }

        private void CalculateTax()
        {
            if (Summary.TaxAmount.Percent > 0)
            {
                var taxRate = new TaxRate(Summary.TaxAmount.Code, Summary.TaxAmount.Name, Summary.TaxAmount.Percent);
                var taxAmount = taxRate.Apply(Summary.SubTotal - Summary.DiscountTotalAmount + Summary.ChargeAmount);
                this.Summary = new Summary(taxAmount, Summary.DiscountTotalAmount, Summary.ChargeAmount, Summary.SubTotal);
            }
        }

        private Item GetItem(Guid itemId)
        {
            var item = Items.FirstOrDefault(i => i.Id.Equals(itemId));
            if (Object.ReferenceEquals(item, null))
                throw new Exception("Item not found");
            return item;
        }

        private Item GetItem(Product product)
        {
            return Items.FirstOrDefault(i => i.Product.Id.Equals(product.Id));
        }

        private bool IsExistsInItemRemoved(Item item)
        {
            return ItemsRemoved.Count(i => i.Product.Id.Equals(item.Product.Id)) > 0;
        }

        private void AssertPaymentAmountAcceptable(double amount)
        {
            if (amount < Summary.NetAmount)
                throw new PaymentAmountNotEnoughException();
            if (amount > (this.Summary.NetAmount + 1000000D))
                throw new PaymentAmountTooExcessiveException();
        }

        #endregion
    }
}
