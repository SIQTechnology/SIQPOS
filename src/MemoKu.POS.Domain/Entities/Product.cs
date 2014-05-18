using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public double Price { get; private set; }

        private Product() { }

        public Product(Guid id, string name, string barcode, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Barcode = barcode;
            this.Price = price;
        }

        public void ChangePrice(double price)
        {
            this.Price = price;
        }
    }
}
