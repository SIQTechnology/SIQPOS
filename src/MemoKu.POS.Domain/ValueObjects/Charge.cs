using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.ValueObjects
{
    public enum ChargeType
    {
        None,
        Percent,
        Nominal
    }
    public class ChargeRate
    {
        public ChargeType ChargeType { get; private set; }
        public double Rate { get; private set; }

        private ChargeRate() { }

        public ChargeRate(ChargeType typeOfCharge, double rate)
        {
            this.ChargeType = typeOfCharge;
            this.Rate = rate;
        }

        public static ChargeRate None
        {
            get { return new ChargeRate(); }
        }

        internal ChargeAmount Apply(double amountToCharge)
        {
            double chargePercent = ChargeType == ChargeType.Percent ? Rate : ((Rate / amountToCharge) * 100);
            double chargeAmount = ChargeType == ChargeType.Percent ? ((Rate / 100) * amountToCharge) : Rate;
            return new ChargeAmount(chargePercent, chargeAmount);
        }
    }

    public class ChargeAmount
    {
        public double Percent { get; private set; }
        public double Amount { get; private set; }

        public ChargeAmount() { }
        public ChargeAmount(double percent, double amount)
        {
            this.Percent = percent;
            this.Amount = amount;
        }

        public static double operator +(double left, ChargeAmount chargeAmount)
        {
            return left + chargeAmount.Amount;
        }
    }
}
