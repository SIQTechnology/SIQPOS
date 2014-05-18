using MemoKu.POS.Domain;
using MemoKu.POS.Domain.Repositories;
using MemoKu.POS.Domain.Repository;
using MemoKu.POS.Domain.Services;
using MemoKu.POS.Mvc.Sessions;
using MemoKu.POS.Reporting;
using MemoKu.POS.Repositories;
using StructureMap;

namespace MemoKu.POS.App_Start
{
    public static class StructureMapConfig
    {
        public static void RegisterServices()
        {
            var sessionHolder = new SessionHolder();
            ObjectFactory.Initialize(i =>
            {
                i.ForSingletonOf<SessionHolder>().Use(sessionHolder);
                i.ForSingletonOf<IShoppingCartSingleton>().Use(sessionHolder);
                i.For<IAccountRepository>().Use<AccountRepository>();
                i.For<ISessionRepository>().Use<SessionRepository>();
                i.For<SessionService>().Use<SessionService>();
                i.For<ICompanyProfileRepository>().Use<CompanyProfileRepository>();
                i.For<IDatabaseManagement>().Use<DatabaseManagement>();
                i.For<IPOSSettingRepository>().Use<POSSettingRepository>();
                i.For<IProductRepository>().Use<ProductRepository>();
                i.For<IAutoNumberRepository>().Use<AutoNumberRepository>();
                i.For<AutoNumberGenerator>().Use<AutoNumberGenerator>();
            });
        }

        public static void RegisterSessionControl()
        {
            
        }
    }
}
