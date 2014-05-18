using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.ValueObjects
{
    public enum DiscountType
    {
        None,
        Percent,
        Nominal
    }

    public class DiscountRate
    {
        public DiscountType DiscountType { get; private set; }
        public double Rate { get; private set; }

        private DiscountRate() { }

        public DiscountRate(DiscountType discType, double rate)
        {
            this.DiscountType = discType;
            this.Rate = rate;
        }

        internal DiscountAmount Apply(double amountToDiscount, int qtyToDiscount)
        {
            if (amountToDiscount == 0d)
                return new DiscountAmount(0, 0);
            double discPercent = DiscountType == DiscountType.Percent ? Rate : (Rate / amountToDiscount) * 100;
            double discAmount = DiscountType == DiscountType.Nominal ? Rate * Math.Abs(qtyToDiscount) : (Rate * amountToDiscount) / 100;
            return new DiscountAmount(discPercent, discAmount);
        }

        internal bool IsZero()
        {
            return Rate.Equals(0D);
        }

        public static DiscountRate None
        {
            get { return new DiscountRate(); }
        }
    }

    public class DiscountAmount
    {
        public double Percent { get; private set; }
        public double Amount { get; private set; }

        private DiscountAmount() { }

        public DiscountAmount(double percent, double amount)
        {
            this.Percent = percent;
            this.Amount = amount;
        }

        internal bool IsZero()
        {
            return Percent.Equals(0d);
        }

        public static double operator *(double left, DiscountAmount right)
        {
            return left * right.Amount;
        }

        public static double operator -(double left, DiscountAmount right)
        {
            return left - right.Amount;
        }
    }
}
