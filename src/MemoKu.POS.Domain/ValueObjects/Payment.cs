using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.ValueObjects
{
    public enum PaymentTypes : int
    {
        Cash = 0,
        Card = 1,
        MixedPayment = 2
    }

    public class Payment
    {
        public PaymentTypes Type { get; private set; }
        public double PayAmount { get; private set; }
        public double ChangeAmount { get; private set; }

        public Payment(PaymentTypes type, double payAmount, double changeAmount)
        {
            this.Type = type;
            this.PayAmount = payAmount;
            this.ChangeAmount = changeAmount;
        }
    }
}
