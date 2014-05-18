using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Exceptions;
using MemoKu.POS.Domain.Repositories;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Domain.Services
{
    public class ShoppingCartService
    {
        private IProductRepository productRepository;
        private IShoppingCartSingleton shoppingCartSingleton;
        private AutoNumberGenerator autoNumberGenerator;
        private ICurrencyRepository currencyRepository;
        private ITaxRepository taxRepository;
        private IServiceChargeRepository serviceChargeRepository;
        public ShoppingCartService(IProductRepository productRepository, IShoppingCartSingleton shoppingCartSingleton, AutoNumberGenerator autoNumberGenerator, ICurrencyRepository currencyRepository, ITaxRepository taxRepository, IServiceChargeRepository serviceChargeRepository)
        {
            this.productRepository = productRepository;
            this.shoppingCartSingleton = shoppingCartSingleton;
            this.autoNumberGenerator = autoNumberGenerator;
            this.currencyRepository = currencyRepository;
            this.taxRepository = taxRepository;
            this.serviceChargeRepository = serviceChargeRepository;
        }

        public void Create(Guid sessionId, string userName)
        {
            var currency = currencyRepository.Default();
            var tax = taxRepository.Get();
            var serviceCharge = serviceChargeRepository.Get();
            var sc = new ShoppingCart(sessionId, userName, currency, tax, serviceCharge);
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        public Guid AddItem(string code)
        {
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            var product = productRepository.GetByBarcodeOrCode(code);
            DiscountRate discountRate = DiscountRate.None;
            AssertProductNotNull(product, code);
            var itemId = sc.AddItem(product, discountRate);
            shoppingCartSingleton.SetShoppingCart(sc);
            return itemId;
        }

        public void ChangeQuantity(Guid itemId, int qty)
        {
            AssertItemIdNotGuidEmpty(itemId);
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            sc.ChangeQuantity(itemId, qty);
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        public void IncreaseQuantity(Guid itemId)
        {
            AssertItemIdNotGuidEmpty(itemId);
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            sc.IncreaseQuantity(itemId);
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        public void DecreaseQuantity(Guid itemId)
        {
            AssertItemIdNotGuidEmpty(itemId);
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            sc.DecreaseQuantity(itemId);
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        public void DeleteItem(Guid itemId, string removeBy)
        {
            AssertItemIdNotGuidEmpty(itemId);
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            sc.DeleteItem(itemId, removeBy);
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        public void ChangePrice(Guid itemId, double price)
        {
            AssertItemIdNotGuidEmpty(itemId);
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            sc.ChangePrice(itemId, price);
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        public void Pay(double payAmount, string organizationId, string clientId)
        {
            ShoppingCart sc = shoppingCartSingleton.ShoppingCart;
            sc.Pay(payAmount, (date) =>
            {
                return autoNumberGenerator.Generate(organizationId, clientId, date);
            });
            shoppingCartSingleton.SetShoppingCart(sc);
        }

        private void AssertItemIdNotGuidEmpty(Guid itemId)
        {
            if (itemId.Equals(Guid.Empty))
                throw new NoItemSelectedException();
        }

        private void AssertProductNotNull(Entities.Product product, string code)
        {
            if (Object.ReferenceEquals(product, null))
                throw new ProductNotFoundException(code);
        }
    }
}
