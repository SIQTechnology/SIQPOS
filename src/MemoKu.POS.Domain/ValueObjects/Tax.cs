using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.ValueObjects
{
    public class TaxRate
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        /// <summary>
        /// percentage
        /// </summary>
        public double Rate { get; private set; }

        private TaxRate() { }

        public TaxRate(string code, string name, double rate)
        {
            this.Code = code;
            this.Name = name;
            this.Rate = rate;
        }

        internal TaxAmount Apply(double amountToTax)
        {
            return new TaxAmount(Code, Name, Rate, (Rate / 100) * amountToTax);
        }

        public static TaxRate None
        {
            get { return new TaxRate(); }
        }
    }

    public class TaxAmount
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        /// <summary>
        /// Percentage
        /// </summary>
        public double Percent { get; private set; }
        /// <summary>
        /// Tax Amount
        /// </summary>
        public double Amount { get; private set; }

        public TaxAmount(string code, string name, double percent, double amount)
        {
            this.Code = code;
            this.Name = name;
            this.Percent = percent;
            this.Amount = amount;
        }

        public static double operator +(double left, TaxAmount tax)
        {
            return left + tax.Amount;
        }
    }
}
