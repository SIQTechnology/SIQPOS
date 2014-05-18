using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Domain.Entities;

namespace MemoKu.POS.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetByBarcodeOrCode(string barcode);
    }
}
