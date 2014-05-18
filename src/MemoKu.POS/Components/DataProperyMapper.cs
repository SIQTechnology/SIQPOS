using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Components
{
    public class DataProperyMapper
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string PartCode { get; set; }
        public DataProperyMapper()
        {
            Id = "Id";
            Name = "ProductName";
            Qty = "Quantity";
            Price = "Price";
            Amount = "Total";
            PartCode = "PartCode";
        }

        public DataProperyMapper(string id, string name, string qty, string price, string amount, string partCode)
        {
            this.Id = id;
            this.Name = name;
            this.Qty = qty;
            this.Price = price;
            this.Amount = amount;
            this.PartCode = partCode;
        }
    }
}
