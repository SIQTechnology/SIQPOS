using System;
using Machine.Specifications;
using MemoKu.POS.Domain;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.Repositories;
using MemoKu.POS.Domain.Repository;
using MemoKu.POS.Domain.Services;
using MemoKu.POS.Mvc.Sessions;
using MemoKu.POS.Reporting;
using MemoKu.POS.Reporting.Models;
using StructureMap;

namespace MemoKu.Test.context
{
    public class TestBase
    {
        protected static Product product_1;
        Establish ctx = () =>
        {
            TestContext.Initialize();
            var sessionHolder = ObjectFactory.GetInstance<SessionHolder>();

            POSUser user = new POSUser("dennywu", new string[] { }, new string[] { });
            sessionHolder.SetSession(new POSSession(user.Username));
        };

        public static class TestContext
        {
            public static void Initialize()
            {
                IAccountRepository accRepo = new Moq.Mock<IAccountRepository>().Object;
                ISessionRepository sessionRepo = new Moq.Mock<ISessionRepository>().Object;
                IPOSSettingRepository posSettingRepo = new Moq.Mock<IPOSSettingRepository>().Object;
                Moq.Mock<IProductRepository> productRepo = new Moq.Mock<IProductRepository>();
                product_1 = new Product(Guid.NewGuid(), "Product ABC", "001", "001", 2000);
                productRepo.Setup(i => i.GetByBarcodeOrCode("001")).Returns(product_1);

                Moq.Mock<ICompanyProfileRepository> cpRepo = new Moq.Mock<ICompanyProfileRepository>();
                cpRepo.Setup(i => i.Get()).Returns(new CompanyProfile("denny@memoku.com", "123", "Toko Dny", "Diamond Palace", null));

                AutoNumber autoNumber = new AutoNumber("denny@memoku.com", "123", DateTime.Now);
                Moq.Mock<IAutoNumberRepository> autoNumberRepo = new Moq.Mock<IAutoNumberRepository>();
                autoNumberRepo.Setup(i => i.Get(DateTime.Now)).Returns(autoNumber);

                var sessionHolder = new SessionHolder();
                ObjectFactory.Initialize(i =>
                {
                    i.For<IAccountRepository>().Use(accRepo);
                    i.For<ISessionRepository>().Use(sessionRepo);
                    i.For<ICompanyProfileRepository>().Use(cpRepo.Object);
                    i.For<SessionService>().Use<SessionService>();
                    i.For<ShoppingCartService>().Use<ShoppingCartService>();
                    i.ForSingletonOf<SessionHolder>().Use<SessionHolder>();
                    i.For<IProductRepository>().Use(productRepo.Object);
                    i.For<IPOSSettingRepository>().Use(posSettingRepo);
                    i.ForSingletonOf<SessionHolder>().Use(sessionHolder);
                    i.ForSingletonOf<IShoppingCartSingleton>().Use(sessionHolder);
                    i.For<IAutoNumberRepository>().Use(autoNumberRepo.Object);
                    i.For<AutoNumberGenerator>().Use<AutoNumberGenerator>();
                });
            }
        }
    }
}
