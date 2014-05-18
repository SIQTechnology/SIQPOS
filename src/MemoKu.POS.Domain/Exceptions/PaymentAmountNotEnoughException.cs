using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Domain.Exceptions
{
    public class PaymentAmountNotEnoughException : Exception
    {
        public PaymentAmountNotEnoughException()
            : base("Jumlah pembayaran tidak cukup.")
        {
        }
    }
}
