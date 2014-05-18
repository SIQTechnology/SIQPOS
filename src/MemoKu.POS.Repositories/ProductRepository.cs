using System;
using System.Data.SqlServerCe;
using MemoKu.POS.Database;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.Repositories;

namespace MemoKu.POS.Repositories
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Get Product By Barcode or Code
        /// </summary>
        /// <param name="barcode">Barcode Or Code</param>
        /// <returns>Product</returns>
        public Product GetByBarcodeOrCode(string barcode)
        {
            var sqlStatement = "SELECT * FROM tblproduct WHERE barcode = @barcode or code = @barcode";
            Product product = SQLCeDb.Find<Product>(sqlStatement).AddParameter("barcode", barcode.Trim()).Than.DeserializeUsing(ProductDeserializer).ReturnOne();
            return product;
        }

        private Product ProductDeserializer(SqlCeDataReader reader)
        {
            var id = Guid.Parse(reader["id"].ToString());
            var name = reader["name"].ToString();
            var barcode = reader["barcode"].ToString();
            var price = Convert.ToDouble(reader["price"]);
            return new Product(id, name, barcode, price);
        }
    }
}
