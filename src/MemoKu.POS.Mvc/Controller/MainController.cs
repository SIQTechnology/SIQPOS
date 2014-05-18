using System.Windows.Forms;
using MemoKu.POS.Mvc.Interface;
using StructureMap;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Domain.Services;
using MemoKu.POS.Reporting;
using MemoKu.POS.Reporting.Models;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Mvc.Controller
{
    public class MainController : IMainController
    {
        private IMainView m_view;
        private IModeController mode_ctrl;
        private readonly SessionService sessionService = ObjectFactory.GetInstance<SessionService>();
        private readonly ShoppingCartService shoppingCartService = ObjectFactory.GetInstance<ShoppingCartService>();
        private readonly ICompanyProfileRepository companyProfileRepository = ObjectFactory.GetInstance<ICompanyProfileRepository>();

        public MainController(IMainView m_view, ISearchPartView searchPartView)
        {
            mode_ctrl = new ModeController(this, m_view, searchPartView);
            this.m_view = m_view;
        }

        public void Start()
        {
            sessionService.OpenSession(Context.Session.POSUser.Username);
            CompanyProfile cp = companyProfileRepository.Get();
            if (cp.IsNull())
                throw new CompanyProfileNotFoundException();
            Context.Session.SetCompanyProfile(cp);
            m_view.SetCompanyProfile(cp);
            CreateNewTransaction();
        }

        public void CreateNewTransaction()
        {
            m_view.Clear();
            mode_ctrl.ChangeToScanMode();
            var sessionId = Context.Session.POSSession.Id;
            var userName = Context.Session.POSUser.Username;
            shoppingCartService.Create(sessionId, userName);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            mode_ctrl.Action(e);
        }

        public void CloseSession()
        {
            sessionService.CloseSession(Context.Session.POSSession);
        }
    }
}
