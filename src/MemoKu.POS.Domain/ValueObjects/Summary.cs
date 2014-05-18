using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain.Entities;

namespace MemoKu.POS.Domain.ValueObjects
{
    public class Summary
    {
        public double SubTotal { get; private set; }
        public DiscountAmount DiscountTotalAmount { get; private set; }
        public ChargeAmount ChargeAmount { get; private set; }
        public TaxAmount TaxAmount { get; private set; }
        public double NetAmount { get; private set; }

        public Summary(TaxAmount taxAmount, DiscountAmount discountTotalAmount, ChargeAmount chargeAmount, double amountBeforeDiscount)
        {
            this.SubTotal = amountBeforeDiscount;
            this.DiscountTotalAmount = discountTotalAmount;
            this.ChargeAmount = chargeAmount;
            this.TaxAmount = taxAmount;
            this.NetAmount = SubTotal - discountTotalAmount + ChargeAmount + TaxAmount;
        }
    }
}
