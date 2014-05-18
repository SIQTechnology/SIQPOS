using System;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.Repository;

namespace MemoKu.POS.Domain.Services
{
    public class SessionService
    {
        private ISessionRepository sessionRepository;
        private IShoppingCartSingleton shoppingCartSingleton;
        public SessionService(ISessionRepository sessionRepository, IShoppingCartSingleton shoppingCartSingleton)
        {
            this.sessionRepository = sessionRepository;
            this.shoppingCartSingleton = shoppingCartSingleton;
        }

        public POSSession OpenSession(string userName)
        {
            POSSession session = sessionRepository.GetSessionOpened(userName);
            if (Object.ReferenceEquals(session, null))
            {
                session = new POSSession(userName);
                DateTime lastSession = sessionRepository.GetLastCloseDate(userName);
                if (!lastSession.Equals(new DateTime()))
                    if (session.OpenDate <= lastSession.AddDays(-7))
                        throw new Exception("Tanggal komputer anda salah. silahkan di perbaharui terlebih dahulu");
                sessionRepository.Save(session);
            }
            shoppingCartSingleton.SetSession(session);
            return session;
        }

        public void CloseSession(POSSession session)
        {
            session.Close();
            sessionRepository.Update(session);
        }
    }
}
