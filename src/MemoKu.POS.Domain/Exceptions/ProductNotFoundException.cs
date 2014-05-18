using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string code)
            : base(string.Format("Produk dengan barcode atau code {0} tidak ditemukan", code))
        {
        }
    }
}
