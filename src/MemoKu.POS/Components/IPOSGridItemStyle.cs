using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Components
{
    public interface IPOSGridItemStyle
    {
        void SetDataSource(object rowDataSource);
        string GetQty();
        string GetPrice();
        string GetAmount();
        string GetNameDiscountNote();
        string GetAmountDiscountNote();
        string[] GetMultiUnitNotes();
        string[] GetPackageNotes();
        bool NoDiscount();
    }
}
