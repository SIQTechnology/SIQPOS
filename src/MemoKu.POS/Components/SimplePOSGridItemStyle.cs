using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Components
{
    public class SimplePOSGridItemStyle : IPOSGridItemStyle
    {
        DataProperyMapper propMapper;
        object dataSource = new { };
        public SimplePOSGridItemStyle(DataProperyMapper propMapper)
        {
            this.propMapper = propMapper;
        }
        public void SetDataSource(object dataSource)
        {
            this.dataSource = dataSource;
        }
        public string GetQty()
        {
            PropertyInfo qtyProp = dataSource.GetType().GetProperty(propMapper.Qty);
            if (qtyProp == null)
                return "0";

            decimal qty = 0;
            Decimal.TryParse(qtyProp.GetGetMethod().Invoke(dataSource, null).ToString(), out qty);
            return qty.ToString("N");
        }
        public string GetPrice()
        {
            PropertyInfo priceProp = dataSource.GetType().GetProperty(propMapper.Price);
            if (priceProp == null)
                return "0";

            decimal price = 0;
            Decimal.TryParse(priceProp.GetGetMethod().Invoke(dataSource, null).ToString(), out price);
            return price.ToString("N");
        }
        public string GetAmount()
        {
            PropertyInfo amountProp = dataSource.GetType().GetProperty(propMapper.Amount);
            if (amountProp == null)
                return "0";

            decimal amount = 0;
            Decimal.TryParse(amountProp.GetGetMethod().Invoke(dataSource, null).ToString(), out amount);
            return amount.ToString("N");
        }
        public string GetNameDiscountNote()
        {
            return "";
        }
        public string GetAmountDiscountNote()
        {
            return "";
        }
        public string[] GetMultiUnitNotes()
        {
            return new string[1];
        }
        public bool NoDiscount()
        {
            return true;
        }

        #region POSGridItemStyle Members


        public string[] GetPackageNotes()
        {
            return new string[1];
        }
        public string[] GetCargoNotes()
        {
            return new string[1];
        }
        #endregion
    }
}
