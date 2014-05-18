using Machine.Specifications;
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
    public class TestBaseWithNoData
    {
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
                ICompanyProfileRepository cpRepo = new Moq.Mock<ICompanyProfileRepository>().Object;
                IProductRepository productRepo = new Moq.Mock<IProductRepository>().Object;
                IPOSSettingRepository posSettingRepo = new Moq.Mock<IPOSSettingRepository>().Object;
                ObjectFactory.Initialize(i =>
                {
                    i.For<IAccountRepository>().Use(accRepo);
                    i.For<ISessionRepository>().Use(sessionRepo);
                    i.For<ICompanyProfileRepository>().Use(cpRepo);
                    i.For<SessionService>().Use<SessionService>();
                    i.For<ShoppingCartService>().Use<ShoppingCartService>();
                    i.ForSingletonOf<SessionHolder>().Use<SessionHolder>();
                    i.For<IProductRepository>().Use(productRepo);
                    i.For<IPOSSettingRepository>().Use(posSettingRepo);
                });
            }
        }
    }
}
